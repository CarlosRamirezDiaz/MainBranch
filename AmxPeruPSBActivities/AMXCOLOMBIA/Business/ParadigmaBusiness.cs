using AMXCommon.Repository.BiHeader;
using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Business
{
    public class ParadigmaBusiness
    {
        private OrganizationServiceProxy organizationService;

        private IndividualCustomerRepository _individualCustomerRepository = null;
        private IndividualCustomerRepository individualCustomerRepository
        {
            get
            {
                if (this._individualCustomerRepository == null)
                    this._individualCustomerRepository = new IndividualCustomerRepository(this.organizationService);
                return this._individualCustomerRepository;
            }
        }

        private UserRepository _userRepository = null;
        private UserRepository userRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new UserRepository(this.organizationService);
                return this._userRepository;
            }
        }

        private BiHeaderRepository _biHeaderRepository = null;
        private BiHeaderRepository biHeaderRepository
        {
            get
            {
                if (this._biHeaderRepository == null)
                    this._biHeaderRepository = new BiHeaderRepository();
                return this._biHeaderRepository;
            }
        }

        public ParadigmaBusiness(OrganizationServiceProxy org)
        {
            this.organizationService = org;
        }

        public string GetIFrameUrl(Guid customerId, Guid userId, string iFrameBaseUrl)
        {
            string returnValue = string.Empty;
            try
            {
                // fetch Base Paradigma iFrame URL
                if (string.IsNullOrEmpty(iFrameBaseUrl))
                    throw new Exception("GetIFrameUrl - PARADIGMA_IFRAME_URL empty on CRM Configuration");

                // Fetch CSR email address
                var csrUser = this.userRepository.GetFirst(userId);

                if (string.IsNullOrEmpty(csrUser.PrimaryEmailAddress))
                    throw new Exception(string.Format("GetIFrameUrl - Primary email address empty for user {0}-{1}", userId, csrUser.FullName));

                // Fetch Open BiHeader for the CSR User
                var biHeader = this.biHeaderRepository.GetActiveBiHeader(userId, this.organizationService);
                if (biHeader.Id == Guid.Empty)
                    throw new Exception(string.Format("GetIFrameUrl - There is not an Open BI Header for user {0}-{1}", userId, csrUser.FullName));
                
                // Fetch Individual account (External Id)
                var individual = this.individualCustomerRepository.GetById(customerId);

                if (string.IsNullOrEmpty(individual.CustomerId))
                    throw new Exception(string.Format("GetIFrameUrl - external Id empty for individual {0}-{1}", customerId, individual.FullName));

                //Example: user1@correo.com|0123456|MiTelmex|CLI|4AC58F57-A6C0-E711-80E5-FA163E10DFBE|34567
                var originalString = string.Format("{0}|{1}|MiTelmex|CLI|{2}|{1}", csrUser.PrimaryEmailAddress, individual.CustomerId, biHeader.Id);

                // Encrypt the originalString

                var keyString = "9p8r7o6x5y4321e0";

                var aes = new RijndaelManaged();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                aes.BlockSize = 128;
                aes.KeySize = 128;
                var aesAlg = new RijndaelManaged();
                var key = new Rfc2898DeriveBytes(keyString, 128);
                aesAlg.Key = key.GetBytes(aes.KeySize / 8);
                aesAlg.IV = key.GetBytes(aes.BlockSize / 8);
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                var msEncrypt = new MemoryStream();
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(originalString);
                }

                var encryptedString = Convert.ToBase64String(msEncrypt.ToArray());

                returnValue = iFrameBaseUrl + encryptedString;

                // dummy value for testing paradigma until it has Claro data to consume.
                returnValue = @"http://facturasclarocert.paradigma.com.co/ebpTelmex/Pages/Bill/Proxy.aspx?tramaTCRM=4MYETicq6u3TXHMsEuTriB3vkD/hdrKhOIuHiizV00X17QgjcCgM0ckd33a/jAZX";
            }
            catch (Exception ex)
            {
                throw new Exception("GetIFrameUrl - " + ex.Message);
            }

            return returnValue;
        }

    }
}

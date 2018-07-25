using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.CreditScore
{
    public class AmxPeruGetCreditScoreResponse : BaseResponse
    {
        public int SucessFlag { get; set; }
        public Individual Individual { get; set; }
        public Corporate Corporate { get; set; }


    }

    public class Individual
    {
        public string Action { get; set; }

        public decimal CreditLimit { get; set; }

        public int ScoreRisk { get; set; }

        public string CreditScore { get; set; }

        public string ProductType { get; set; }

        public string CustomerType { get; set; }

        public string LCOrigin { get; set; }

        public string DocumentNumber { get; set; }

        public string LastName { get; set; }

        public string MotherLastName { get; set; }

        public string Names { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public string TypeCard { get; set; }
        public string Reasons { get; set; }
        public string Analysis { get; set; }
        public string TermSaleEquipment { get; set; }
        public string LimitCreditEquipment { get; set; }
        public string Score { get; set; }

    }

    public class Corporate
    {
        public int Score { get; set; }

        public decimal CreditLimit { get; set; }

        public decimal CreditCardIncome { get; set; }

        public decimal MortgageDebtIncome { get; set; }

        public decimal NonMortgageDebtIncome { get; set; }

        public decimal IntegrateType { get; set; }

        public decimal RepresentativeType { get; set; }

        public string CompanyName { get; set; }

    }

    public class IntegrateType
    {
        public int MemberNumber { get; set; }


        public int DocumentType { get; set; }


        public string DocumentNumber { get; set; }


        public string Name { get; set; }





    }

    public class RepresentativeType
    {
        public string TypePerson { get; set; }
        public int DocumentType { get; set; }

        public string DocumentNumber { get; set; }
        public string Position { get; set; }

        public int DateHome { get; set; }



    }
}

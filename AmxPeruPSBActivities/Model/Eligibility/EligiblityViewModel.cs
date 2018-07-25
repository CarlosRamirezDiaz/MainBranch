using Ericsson.ETELCRM.Entities.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Eligibility
{
    public sealed class EligibilityViewModel
    {
        /// <summary>
        /// The order identifier
        /// </summary>
        private Guid? orderId;

        /// <summary>
        /// The order entity
        /// </summary>
        private etel_ordercapture orderEntity;

        /// <summary>
        /// Gets or sets the order entity.
        /// </summary>
        /// <value>
        /// The order entity.
        /// </value>
        public etel_ordercapture OrderEntity
        {
            get
            {
                return orderEntity;
            }

            set
            {
                orderEntity = value;
                if (orderEntity != null)
                {
                    orderId = null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the order in CRM
        /// </summary>
        public Guid? OrderId
        {
            get
            {
                return orderId;
            }

            set
            {
                orderId = value;
                if (orderId != null && orderId.Value != Guid.Empty)
                {
                    orderEntity = null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the customer in CRM
        /// </summary>
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer type
        /// </summary>
        public int? CustomerType { get; set; }

        /// <summary>
        /// Gets or sets the catalogue name
        /// </summary>
        public Guid? CatalogueId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the sales channel in CRM
        /// </summary>
        public Guid? UserId { get; set; }

        public Guid? ProductId { get; set; }

        public Guid? CreatingContractProductId { get; set; }

    }
}

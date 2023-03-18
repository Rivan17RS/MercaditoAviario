using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;

namespace AppLogic
{
    public class PurchaseOrderManager
    {
        public string CreatePurchaseOrder(Offer offer) 
        {
            PurchaseOrderCrudFactory purchaseOrderCrud = new PurchaseOrderCrudFactory();

            //Se obtienen los datos de la Oferta y del Subscriptor
            PurchaseOrder po = new PurchaseOrder();
            po.Product = offer.Product;
            po.Quantity = offer.Quantity;
            po.Price = offer.Price;
            po.BuyerPerson = offer.Subscriptor.Representative;
            po.CompanyName = offer.Subscriptor.Name;
            po.Email = offer.Subscriptor.Email;
            po.Phone = offer.Subscriptor.Phone;

            //Persistir los datos de la orden de compra en la Base de datos

            purchaseOrderCrud.Create(po);

            return "Purchase Order Created Successfully";

        }

        public List<PurchaseOrder> GetAllPurchaseOrders() 
        {
            PurchaseOrderCrudFactory purchaseOrderCrud = new PurchaseOrderCrudFactory();

            return purchaseOrderCrud.RetrieveAll<PurchaseOrder>();
        }
    }
}

using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class PurchaseOrderMapper : ICrudStatements, IObjectMapper
    {


        public SqlOperation GetCreateStatement(BaseEntity entityDTO)
        {
            
           var operation = new SqlOperation();
            operation.ProcedureName = "SP_CreatePurchaseOrder";

            var po = (PurchaseOrder)entityDTO;

            operation.AddVarcharParam("Product", po.Product);
            operation.AddIntegerParam("Quantity", po.Quantity);
            operation.AddDoubleParam("Price", po.Price);
            operation.AddVarcharParam("CompanyName", po.CompanyName);
            operation.AddVarcharParam("BuyerPerson", po.BuyerPerson);
            operation.AddVarcharParam("Email", po.Email);
            operation.AddVarcharParam("Phone", po.Phone);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_GetAllPurchaseOrders"

            };

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int Id)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entityDTO)
        {
            throw new NotImplementedException();
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
           var purchaseOrder = new PurchaseOrder()
            {
                    Id = int.Parse(row["Id"].ToString()),
                    Product = row["Product"].ToString(),
                    Quantity = int.Parse(row["Quantity"].ToString()),
                    Price = double.Parse(row["Price"].ToString()),
                    CompanyName = row["CompanyName"].ToString(),
                    BuyerPerson = row["BuyerPerson"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString()
            };

            return purchaseOrder;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows) 
            {
                var purchaseOrder = BuildObject(row);
                lstResults.Add(purchaseOrder);
            }

            return lstResults;
        }

    }
}

using DataAccess.Dao;
using DataAccess.Mapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class PurchaseOrderCrudFactory : CrudFactory
    {
        private PurchaseOrderMapper mapper;

        public PurchaseOrderCrudFactory() : base()
        { 
            mapper = new PurchaseOrderMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entityDTO)
        {
            //var po = (PurchaseOrder) entityDTO;
            var sqlOperation = mapper.GetCreateStatement(entityDTO);
            dao.ExcecuteStoredProcedure(sqlOperation);
            
        }

        public override void Delete(BaseEntity entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstResults = new List<T>();
            var dataResults = dao.ExecuteStoredProcedureWithquery(mapper.GetRetrieveAllStatement());

            if (dataResults.Count > 0) 
            {
                var objPo = mapper.BuildObjects(dataResults);

                foreach(var po in objPo) 
                {
                    lstResults.Add((T)Convert.ChangeType(po, typeof(T)));
                }
            }

            return lstResults;

        }

        public override T RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}

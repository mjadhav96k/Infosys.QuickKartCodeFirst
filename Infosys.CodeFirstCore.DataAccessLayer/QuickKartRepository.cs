using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infosys.CodeFirstCore.DataAccessLayer
{
    public class QuickKartRepository
    {
        private QuickKartDBContext context;
        public QuickKartRepository(QuickKartDBContext context)
        {
            this.context = context;
        }
        public int AddCategoryDetailsUsingUSP(string categoryName, out byte categoryId)
        {
            categoryId = 0;
            int noOfRowsAffected = 0;
            int returnResult = 0;
            SqlParameter prmCategoryName = new SqlParameter("@CategoryName", categoryName);
            SqlParameter prmCategoryId = new SqlParameter("@CategoryId", System.Data.SqlDbType.TinyInt);
            prmCategoryId.Direction = System.Data.ParameterDirection.Output;
            SqlParameter prmReturnResult = new SqlParameter("@ReturnResult", System.Data.SqlDbType.Int);
            prmReturnResult.Direction = System.Data.ParameterDirection.Output;
            try
            {
                noOfRowsAffected = context.Database
                                .ExecuteSqlRaw("EXEC @ReturnResult = usp_AddCategory @CategoryName, @CategoryId OUT",
                                               prmReturnResult, prmCategoryName, prmCategoryId);
                returnResult = Convert.ToInt32(prmReturnResult.Value);

                categoryId = Convert.ToByte(prmCategoryId.Value);
            }
            catch (Exception ex)
            {
                categoryId = 0;
                noOfRowsAffected = -1;
                returnResult = -99;
            }
            return returnResult;
        }


    }
}

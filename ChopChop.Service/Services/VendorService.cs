using ChopChop.Entity.EntityFramework;
using ChopChop.Service.IServices;
using ChopChop.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChopChop.Service.Services
{
    public class VendorService: IVendorService
    {
      
        public List<ResultSearchRestaurants> SearchRestaurants(SearchResturant searchResturant)
        {
            List<ResultSearchRestaurants> lstResultSearchRestaurants = new List<ResultSearchRestaurants>();
            using (ChopChopEntities db = new ChopChopEntities())
            {
                try {
                db.Database.Initialize(force: false);
                var cmd = db.Database.Connection.CreateCommand();
                cmd.CommandText = "EXEC SSP_GetRestaurantList  @Lat,@Long,@SortOptionId,@StartIndex,@EndIndex,@LanguageId,@SearchText";
                cmd.Parameters.Add(new SqlParameter("@Lat", (searchResturant.Lat != null && searchResturant.Lat > 0 ? searchResturant.Lat : 0)));
                cmd.Parameters.Add(new SqlParameter("@Long", (searchResturant.Long != null && searchResturant.Long > 0 ? searchResturant.Long : 0)));
                cmd.Parameters.Add(new SqlParameter("@SortOptionId", (searchResturant.SortOptionId != null && searchResturant.SortOptionId > 0 ? searchResturant.SortOptionId : 0)));
                cmd.Parameters.Add(new SqlParameter("@StartIndex", (searchResturant.StartIndex != null ? searchResturant.StartIndex : -1)));
                cmd.Parameters.Add(new SqlParameter("@EndIndex", (searchResturant.EndIndex != null ? searchResturant.EndIndex : -1)));
                cmd.Parameters.Add(new SqlParameter("@LanguageId", (searchResturant.EndIndex != null ? searchResturant.LanguageId : 0)));
                cmd.Parameters.Add(new SqlParameter("@SearchText", (!string.IsNullOrEmpty(searchResturant.SearchText) ? searchResturant.SearchText : "")));
                db.Database.Connection.Open();
                var reader = cmd.ExecuteReader();
                lstResultSearchRestaurants = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<ResultSearchRestaurants>(reader).ToList();
            
                }
                catch (Exception ex) { 
                
                }
                finally {
                    db.Database.Connection.Close();
                }

            }
            return lstResultSearchRestaurants;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomticket_api.models
{
    public class DepartmentModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("online")]
        public bool Online { get; set; }
        [JsonProperty("categorias")]
        public IEnumerable<DepartmentCategory> Categories { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public static string GetDepartmentByName(string departmentname)
        {
            var response = HttpHandler.GetResponse(new EndPoint(TomTicket.Token).ListDepartmentsEndPoint);
            var obj = response.ToObject<DepartmentResponseModel>();

            var result = obj.Departments.Where(x => x.Name == departmentname).Single().Id;

            return result;
        }

        public static DepartmentResponseModel GetDepartments()
        {
            var response = HttpHandler.GetResponse(new EndPoint(TomTicket.Token).ListDepartmentsEndPoint);
            var obj = response.ToObject<DepartmentResponseModel>();

            return obj;
        }

        public static DepartmentCategory GetCategory(string departmentid, string name)
        {
            var response = HttpHandler.GetResponse(new EndPoint(TomTicket.Token).ListDepartmentsEndPoint);
            var obj = response.ToObject<DepartmentResponseModel>();

            var department = obj.Departments.Where(x => x.Id == departmentid).Single();
            var category = department.Categories.Where(x => x.Name == name).Single();

            return category;
        }

        public static IEnumerable<DepartmentCategory> GetCategoriesByDepartmentId(string departmentid)
        {
            var response = HttpHandler.GetResponse(new EndPoint(TomTicket.Token).ListDepartmentsEndPoint);
            var obj = response.ToObject<DepartmentResponseModel>();
            var categories = obj.Departments.Where(x => x.Id == departmentid).Single().Categories;

            return categories;
        }

        public static IEnumerable<DepartmentCategory> GetCategoriesByDepartmentName(string departmentname)
        {
            var response = HttpHandler.GetResponse(new EndPoint(TomTicket.Token).ListDepartmentsEndPoint);
            var obj = response.ToObject<DepartmentResponseModel>();
            var categories = obj.Departments.Where(x => x.Name == departmentname).Single().Categories;

            return categories;
        }
    }
}

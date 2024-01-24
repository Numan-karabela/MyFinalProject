using Entities.Concreet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    static class Messages
    {
        public static string ProductAdded = "ürün Eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";
        public static string MaintenanceTime="Sistem bakımda";
        public static string ProductsListed="Ürünler listelendi";
        public static string ProductCountOfCategoryError = "Fazla yükleme hatası";
        public static string ProductNameAlreadyExists = "Bu işimde zaten bir ürün var"; 
        public static string CategoryLimitExceded = "CategoryLimitine ulaşıldı"; 
        public static string AuthorizationDenied = "Yetkiniz Yok";
    }
}

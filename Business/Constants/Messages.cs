using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //static yapılar new lenmez. Direk masseges. diyoruz uygulama hayatı boyunca tek instance oluyor
    public static class Messages
    {
        //public olduğu için PascalCase yazıyoruz.
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string ProductsListed = "Ürünler listelendi.";
        internal static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir.";
        internal static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var.";
        internal static string CategoryLimitExceded = "Kategori limit aşıldığı için yeni ürün eklenemiyor";
    }
}

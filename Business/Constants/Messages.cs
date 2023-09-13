using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //Authorization Messages
        public static string AuthorizationDenied = "Yetki Reddedildi!";

        // CategoryManager Business Messages
        public static string CategoryAdded = "Yeni Kategori Eklendi!";
        public static string CategoriesListed = "Kategoriler Listelendi!";
        public static string CategoryUpdated = "Kategori Güncellendi!";
        public static string SelectedCategory = "Seçilen Kategori Alındı!";
        public static string CategoryDeleted = "Kategori Silindi!";
        public static string CategoryNotFound = "Kategori Bulunamadı!";

        //CompanyManager Bussiness Messages
        internal static string CompanyAdded = "Yeni Şirket Eklendi!";
        internal static string CompanyNotFound = "Şirket Bulunamadı!";
        internal static string CompanyDeleted = "Şirket Silindi!";
        internal static string CompaniesListed = "Şirketler Listelendi!";
        internal static string SelectedCompany = "Seçilen Şirket Alındı!";
        internal static string CompanyUpdated = "Şirket Güncellendi!";
    }
}

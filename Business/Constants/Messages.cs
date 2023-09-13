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
        public static string CategoryDeleted = "Seçilen Kategori Silindi!";
        public static string CategoryNotFound = "Kategori Bilgisi Bulunamadı!";

        //CompanyManager Bussiness Messages
        internal static string CompanyAdded = "Yeni Şirket Eklendi!";
        internal static string CompanyNotFound = "Şirket Bulunamadı!";
        internal static string CompanyDeleted = "Seçilen Şirket Silindi!";
        internal static string CompaniesListed = "Şirketler Listelendi!";
        internal static string SelectedCompany = "Seçilen Şirket Alındı!";
        internal static string CompanyUpdated = "Şirket Bilgisi Güncellendi!";

        //CustomerManager Business Messages
        internal static string CustomerAdded = "Yeni Müşteri Eklendi!";
        internal static string CustomersListed = "Müşteriler Listelendi!";
        internal static string CustomerDeleted = "Seçilen Müşteri Silindi!";
        internal static string CustomerNotFound = "Müşteri Bulunamadı!";
        internal static string SelectedCustomer = "Seçilen Müşteri Alındı!";
        internal static string CustomerUpdated = "Müşteri Bilgisi Güncellendi!";
    }
}

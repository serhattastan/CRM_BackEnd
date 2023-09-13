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
        public static string CompanyAdded = "Yeni Şirket Eklendi!";
        public static string CompanyNotFound = "Şirket Bulunamadı!";
        public static string CompanyDeleted = "Seçilen Şirket Silindi!";
        public static string CompaniesListed = "Şirketler Listelendi!";
        public static string SelectedCompany = "Seçilen Şirket Alındı!";
        public static string CompanyUpdated = "Şirket Bilgisi Güncellendi!";

        //CustomerManager Business Messages
        public static string CustomerAdded = "Yeni Müşteri Eklendi!";
        public static string CustomersListed = "Müşteriler Listelendi!";
        public static string CustomerDeleted = "Seçilen Müşteri Silindi!";
        public static string CustomerNotFound = "Müşteri Bulunamadı!";
        public static string SelectedCustomer = "Seçilen Müşteri Alındı!";
        public static string CustomerUpdated = "Müşteri Bilgisi Güncellendi!";

        //OfferManager Business Messages
        public static string OfferDeleted = "Seçilen Teklif Silindi!";
        public static string OfferAdded = "Yeni Teklif Eklendi!";
        public static string OffersListed = "Teklifler Listelendi!";
        public static string SelectedOffer = "Seçilen Teklif Alındı!";
        public static string OfferUpdated = "Teklif Bilgisi Güncellendi!";
        public static string OfferNotFound = "Teklif Bulunamadı!";

        //ProductManager Business Messages
        public static string ProductAdded = "Ürün Eklendi!";
        public static string ProductDeleted = "Seçilen Ürün Silindi!";
        public static string ProductsListed = "Ürünler Listelendi!";
        public static string SelectedProduct = "Seçilen Ürün Alındı!";
        public static string ProductUpdated = "Ürün Bilgisi Güncellendi!";

        //SaleManager Business Messages
        public static string SaleAdded = "Satış Eklendi!";
        public static string SaleDeleted = "Satış Silindi!";
        public static string SaleNotFound = "Satış Bulunamadı!";
        public static string SalesListed = "Satışlar Listelendi!";
        public static string SelectedSale = "Seçilen Satış Getirildi!";
        public static string SaleUpdated = "Satış Bilgileri Güncellendi!";

        //SectorManager Business Messages
        public static string SectorAdded = "Yeni Sektör Eklendi!";
        public static string SectorDeleted = "Seçilen Sektör Silindi";
        public static string SectorNotFound = "Sektör Bulunamadı!";
        public static string SectorsListed = "Sekörler Listelendi!";
        public static string SelectedSector = "Seçili Sektör Alındı!";
        public static string SectorUpdated = "Sektör Bilgisi Güncellendi!";

        //CommunicationHistoryManager Business Messages
        public static string CommunicationHistoryAdded = "İletişim Geçmişi Bilgisi Eklendi!";
        public static string CommunicationHistoryDeleted = "İletişim Geçmişi Bilgisi Silindi!";
        public static string CommunicationHistoryNotFound = "İletişim Geçmişi Bilgisi Bulunamadı!";
        public static string CommunicationHistoryListed = "İletişim Geçmişi Listelendi!";
        public static string SelectedCommunicationHistory = "Seçili İletişim Geçmişi Bilgisi Alındı!";
        public static string CommunicationHistoryUpdated = "İletişim Geçmişi Bilgisi Güncellendi!";
    }
}

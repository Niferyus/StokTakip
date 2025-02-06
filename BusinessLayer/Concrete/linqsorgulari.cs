//using DataAccessLayer.Concrete;
//using EntityLayer.Concrete;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BusinessLayer.Concrete
//{
//    internal class linqsorgulari
//    {
//        //private readonly Context context;
//        //public void Linqsorgu1()
//        //{
//        //    //1. Sorgu: Tüm müşteriler
//        //    var sorgu = context.Musteriler.ToList();

//        //    //2. Sorgu: where ile filtreleme
//        //    sorgu = context.Musteriler
//        //        .Where(c => c.MusteriAdi == "Furkan")
//        //        .ToList();
//        //    //3. Sorgu: Seçim yapmak
//        //    var sorgu4 = context.Musteriler
//        //        .Select(c => new
//        //        {
//        //            c.MusteriAdi,
//        //            c.MusteriSoyadi
//        //        }).ToList();
//        //    //4. Sorgu: Sıralamalar
//        //    // Büyükten küçüğe
//        //    sorgu = context.Musteriler
//        //        .OrderBy(c => c.MusteriID)
//        //        .ToList();
//        //    // Küçükten Büyüğe
//        //    sorgu = context.Musteriler
//        //        .OrderByDescending(c => c.MusteriID)
//        //        .ToList();
//        //    //5. Sorgu: 
//        //    var sorgu5 = context.Musteriler
//        //        .Where(c => c.MusteriAdi == "Furkan")
//        //        .Count();
//        //    //6. Sorgu
//        //    //Lambda sözdizimi
//        //    var sorgu6 = context.Islemler
//        //        .Join(context.Musteriler,
//        //        islem => islem.MusteriID,
//        //        musteri => musteri.MusteriID,
//        //        (islem, musteri) => new
//        //        {
//        //            CustomerName = musteri.MusteriAdi,
//        //            OrderDate = islem.Tarih,

//        //        }).ToList();
//        //    //query sözdizimi
//        //    var sorgu7 = from islem in context.Islemler
//        //                 join musteri in context.Musteriler on islem.MusteriID equals musteri.MusteriID
//        //                 select new
//        //                 {
//        //                     CustomerName = musteri.MusteriAdi,
//        //                     OrderDate = islem.Tarih,
//        //                 };
//        //    sorgu7.ToList();

//        //    //7. Sorgu 
//        //    var maxvalue = context.Urunler
//        //        .Max(c => c.UrunFiyat);
//        //    var mindate = context.Islemler
//        //        .Min(c => c.Tarih);
//        //    var totalprice = context.Urunler
//        //        .Sum(c => c.UrunFiyat);
//        //    var averageprice = context.Urunler
//        //        .Average(c => c.UrunFiyat);

//        //    //8. Sorgu
//        //    var sorgu8 = context.Islemler
//        //        .Join(context.Urunler,
//        //        islem => islem.UrunID,
//        //        urun => urun.UrunID,
//        //        (islem, urun) => new
//        //        {
//        //            ProductName = urun.UrunAdi,
//        //            TotalPrice = islem.ToplamFiyat
//        //        })
//        //        .GroupBy(item => item.ProductName)
//        //        .Select(group => new
//        //        {
//        //            ProductName = group.Key,
//        //            Total = group.Sum(item => item.TotalPrice)
//        //        }).ToList();

//            //9. Sorgu
//            //var courseStats = from student in context.Students
//            //                  group student by student.CourseId into studentGroup
//            //                  join course in context.Courses on studentGroup.Key equals course.Id
//            //                  select new
//            //                  {
//            //                      CourseName = course.Name,
//            //                      StudentCount = studentGroup.Count(),
//            //                      AverageId = studentGroup.Average(s => s.Id),
//            //                      MaxId = studentGroup.Max(s => s.Id),
//            //                      MinId = studentGroup.Min(s => s.Id)
//            //                  };

//            //var numbers = new List<int> { 1, 2, 3, 4, 5 };
//            //var firstEven = numbers.First(n => n % 2 == 0); // 2
//            //var firstOrDefault = numbers.FirstOrDefault(n => n > 10); // 0 (default değer)
//            //var single = numbers.Single(n => n == 3); // 3
//            //var singleOrDefault = numbers.SingleOrDefault(n => n == 10);
//        }
//    }
//}

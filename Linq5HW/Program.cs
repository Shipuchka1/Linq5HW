using Linq5HW.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq5HW
{

    class Program
    {
        public static Model1 db = new Model1();
        public static string conStr = @"Data Source = DESKTOP-NESB2OL\SQLEXPRESS; Initial Catalog = Linq5; User Id = Natalya; Password = 12345; ";
        static void Main(string[] args)
        {
            //Task2AndTask3();
           // Task4();
            //Task5();
            //Task6();
            Task7();
        }

       public static void Task2AndTask3()
        {
            //2.Используя класс DataContext произвести
            //    выборку данных из таблицы TableEquipmentHistory
            //    и newEquipment используя при этом join выгрузить
            //    следующие данные: intGarageRoom, strSerialNo,
            //intTypeHistory, dStartDate, dEndDate, intDaysCount, intStatys

            Table<TableEquipmentHistory> tabEqHis = db.GetTable<TableEquipmentHistory>();
            Table<newEquipment> newEq = db.GetTable<newEquipment>();

            var jtabs = from a in tabEqHis
                        join b in newEq on a.intEquipmentID equals b.intEquipmentID
                        select new
                        {
                            a.intEquipmentID,
                            b.intGarageRoom,
                            b.strSerialNo,
                            a.intTypeHistory,
                            a.dStartDate,
                            a.dEndDate,
                            a.intDaysCount,
                            a.intStatys
                        };

            foreach (var item in jtabs)
            {
                Console.WriteLine("EquipmentID - " + item.intEquipmentID);
                Console.WriteLine("GarageRoom - " + item.intGarageRoom);
                Console.WriteLine("SerialNo - "+item.strSerialNo);
                Console.WriteLine("TypeHistory - " + item.intTypeHistory);
                Console.WriteLine("StartDate - " + item.dStartDate);
                Console.WriteLine("EndDate - " + item.dEndDate);
                Console.WriteLine("DaysCount - " + item.intDaysCount);
                Console.WriteLine("Statys - " + item.intStatys);
                Console.WriteLine("****************************************");
                Console.WriteLine();
            }

            //3.Из результатов пункта 2, создать таблицу в БД,
            //и результаты первой выборки загрузить во вновь созданную таблицу

            db.ExecuteCommand(" IF not EXISTS(SELECT * FROM sys.tables WHERE name = 'NewTable') begin create table NewTable (NewTableId int primary key identity(1,1)," +
                "EquipmentID int, GarageRoom nvarchar(100),SerialNo nvarchar(100),"+
                "TypeHistory int, StartDate date, EndDate date, DaysCount int, Statys int) end");

            List<NewTable> newTab = new List<NewTable>();
            foreach (var item in jtabs)
            {
            NewTable tab = new NewTable();
                tab.DaysCount = item.intDaysCount;
                tab.EndDate = item.dEndDate;
                tab.EquipmentID = item.intEquipmentID;
                tab.GarageRoom = item.intGarageRoom;
                tab.SerialNo = item.strSerialNo;
                tab.StartDate = item.dStartDate;
                tab.Statys = item.intStatys;
                tab.TypeHistory = item.intTypeHistory;
            newTab.Add(tab);
            }

            Table<NewTable> nt = db.GetTable<NewTable>();
            try
            {
                nt.InsertAllOnSubmit(newTab);
                db.SubmitChanges();
                Console.WriteLine("Данные сохранены в таблицу");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static void Task4()
        {
            //4.Используя присоединённый режим,
            //произвести добавление записей в таблицу newEquipment,
            //при этом необходимо произвести запись данных
            //так же в таблицу TablesManufacturer,
            //для таких моделей как: Audi, BMW,KIA, JEEP

            db.ExecuteCommand("insert TablesManufacturer(strName) values('Audi') "+
               "insert TablesManufacturer(strName) values('BMW')"+
               "insert TablesManufacturer(strName) values('KIA')"+
               "insert TablesManufacturer(strName) values('JEEP')"+
               "insert newEquipment (intManufacturerID,intModelID,intSNPrefixID,intEquipmentTypeID,intSMCSFamilyID,intSizeID," +
               "intMetered,LastDate,intLastMetered,intTotalMetered,bitActive,bitPreservation,bitMeter, bitKTG,isDelete,intLocationId,bitMethodAmortization)" +
               "values(14,77,8778,45,87,2,1,'2017-03-05',9,5,1,1,1,1,1,1,1)");
            Console.WriteLine("Данные добавлены");
        }

        public static void Task5()
        {
            //5.Связать таблицы newEquipment с таблицами: TablesModel, TablesManufacturer:
            //a.используя отложенную загрузку данных
            //b.Использовать оптимальный вариант выгрузки данных,
            //дабы сократить количество обращений к БД запросов.

            Table<newEquipment> newEqTab = db.GetTable<newEquipment>();
            Table<TablesModel> modelTab = db.GetTable<TablesModel>();
            Table<TablesManufacturer> manufTab = db.GetTable<TablesManufacturer>();

            var jres = (from a in newEqTab
                       join b in modelTab on a.intModelID equals b.intModelID
                       join c in manufTab on a.intManufacturerID equals c.intManufacturerID
                       select new
                       {
                           a.intManufacturerID,
                           a.intModelID,
                           a.intEquipmentID,
                           a.intGarageRoom,
                           a.strSerialNo
                       });

            foreach (var item in jres)
            {
               

                Console.WriteLine("intManufacturerID - " + item.intManufacturerID);
                Console.WriteLine("intModelID - " + item.intModelID);
                Console.WriteLine("intEquipmentID - " + item.intEquipmentID);
                Console.WriteLine("intGarageRoom - " + item.intGarageRoom);
                Console.WriteLine("strSerialNo - " + item.strSerialNo);
                Console.WriteLine("***************************");
                
            }


        }

        public static void Task6()
        {
            //6.Написать запрос для выгрузки данных из таблицы newEquipment.
            //Так же написать запрос из таблицы TablesModel,
            //при этом модели машин должны быть только те,
            //которых в таблице newEquipment > 10, 
            //результат этого запроса должен возвращать только intModelID.
            //Далее используя Contains выгрузить данные из таблицы newEquipment.

            Table <newEquipment> newEq = db.GetTable<newEquipment>();
            Table<TablesModel> models = db.GetTable<TablesModel>();

            var resEq = newEq.Select(s =>s);
            var resM = models.Where(w => resEq.Count(r=>r.intModelID==w.intModelID)>10).Select(s=>s.intModelID).ToList();
          
            var result = newEq.Where(w => resM.Contains(w.intModelID)).Select(s => new
            {
                s.intModelID,
                s.strSerialNo,
                s.intEquipmentID,
                s.intManufacturerID,
                s.intGarageRoom
            }).ToList();

            foreach (var item in result)
            {
                Console.WriteLine("intModelID - " + item.intModelID);
                Console.WriteLine("strSerialNo - " + item.strSerialNo);
                Console.WriteLine("intEquipmentID - " + item.intEquipmentID);
                Console.WriteLine("intManufacturerID - " + item.intManufacturerID);
                Console.WriteLine("intGarageRoom - " + item.intGarageRoom);
                Console.WriteLine("*************************************");
            }

        }

        public static void Task7()
        {
            //7.Произвести удаление данных из таблицы TableEquipmentHistory,
            //только те у которых dEndDate пусто.
            //При этом удаление не должно содержать ни какие цыклы.

            Table<TableEquipmentHistory> Hist = db.GetTable<TableEquipmentHistory>();
            List<TableEquipmentHistory> list = Hist.Where(w => w.dEndDate == null || w.dEndDate == DateTime.MinValue).Select(s => s).ToList();
            try
            {
                Hist.DeleteAllOnSubmit(list);
                db.SubmitChanges();
                Console.WriteLine("Данные удалены");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
           
        }
    }
}

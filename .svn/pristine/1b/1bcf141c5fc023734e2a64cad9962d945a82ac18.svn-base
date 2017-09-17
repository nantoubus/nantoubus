using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nantou_bus
{
    public class LocalDatabase
    {
        static object locker = new object();

        public string DBPath { get; set; }

        SQLiteConnection database;

        public LocalDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            DBPath = database.DatabasePath;
            // create the tables
            database.CreateTable<MyRecord>();
            database.CreateTable<History>();
            database.CreateTable<OfficeRecord>();
            database.CreateTable<SchoolRecord>();
        }

        //MyRecord=PreSetHome的table

        //讀取全部資料
        public IEnumerable<MyRecord> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<MyRecord>() select i).ToList();
            }
        }

        //讀取指定x的資料
        public MyRecord GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<MyRecord>().FirstOrDefault(x => x.ID == id);
            }
        }

        //存取資料
        public int SaveItem(MyRecord item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        //刪除資料
        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<MyRecord>(id);
            }
        }


        //刪除全部資料
        public void DeleteAll()
        {
            var fooItems = GetItems().ToList();
            foreach (var item in fooItems)
            {
                DeleteItem(item.ID);
            }
        }

        //History=搜尋記錄的table

        //讀取全部資料
        public IEnumerable<History> GetItemsH()
        {
            lock (locker)
            {
                return (from i in database.Table<History>() select i).ToList();
            }
        }

        //讀取指定x的資料
        public History GetItemH(int id)
        {
            lock (locker)
            {
                return database.Table<History>().FirstOrDefault(x => x.ID == id);
            }
        }

        //存取資料
        public int SaveItemH(History item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        //刪除資料
        public int DeleteItemH(int id)
        {
            lock (locker)
            {
                return database.Delete<History>(id);
            }
        }

        //刪除全部資料
        public void DeleteAllH()
        {
            var fooItems = GetItemsH().ToList();
            foreach (var item in fooItems)
            {
                DeleteItemH(item.ID);
            }
        }


        //officeRecord=PreSetHome的table
        //讀取全部資料
        public IEnumerable<OfficeRecord> GetItemsO()
        {
            lock (locker)
            {
                return (from i in database.Table<OfficeRecord>() select i).ToList();
            }
        }

        //讀取指定x的資料
        public OfficeRecord GetItemO(int id)
        {
            lock (locker)
            {
                return database.Table<OfficeRecord>().FirstOrDefault(x => x.ID == id);
            }
        }

        //存取資料
        public int SaveItemO(OfficeRecord item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        //刪除資料
        public int DeleteItemO(int id)
        {
            lock (locker)
            {
                return database.Delete<OfficeRecord>(id);
            }
        }


        //刪除全部資料
        public void DeleteAllO()
        {
            var fooItems = GetItemsO().ToList();
            foreach (var item in fooItems)
            {
                DeleteItem(item.ID);
            }
        }

        //SchoolRecord=PreSetSchool的table
        //讀取全部資料
        public IEnumerable<SchoolRecord> GetItemsS()
        {
            lock (locker)
            {
                return (from i in database.Table<SchoolRecord>() select i).ToList();
            }
        }

        //讀取指定x的資料
        public SchoolRecord GetItemS(int id)
        {
            lock (locker)
            {
                return database.Table<SchoolRecord>().FirstOrDefault(x => x.ID == id);
            }
        }

        //存取資料
        public int SaveItemS(SchoolRecord item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        //刪除資料
        public int DeleteItemS(int id)
        {
            lock (locker)
            {
                return database.Delete<SchoolRecord>(id);
            }
        }


        //刪除全部資料
        public void DeleteAllS()
        {
            var fooItems = GetItemsS().ToList();
            foreach (var item in fooItems)
            {
                DeleteItemS(item.ID);
            }
        }


    }
}
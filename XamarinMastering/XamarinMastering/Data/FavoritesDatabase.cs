using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinMastering.Data
{
    public class FavoritesDatabase
    {
    //    private readonly SQLite.SQLiteAsyncConnection database;

    //    public FavoritesDatabase(string dbPath)
    //    {
    //        database = new SQLite.SQLiteAsyncConnection(dbPath);

    //        //database.DropTableAsync<Favorite>().Wait();
    //        database.DropTableAsync<NewsCategory>().Wait();

    //        database.CreateTableAsync<NewsCategory>().Wait();
    //        database.CreateTableAsync<Favorite>().Wait();
    //    }

    //    public Task<List<NewsCategory>> GetCategoryAsync() => database.Table<NewsCategory>().ToListAsync();

    //    public Task<List<Favorite>> GetItemsAsync() => database.Table<Favorite>().ToListAsync();

    //    public Task<List<Favorite>> GetItemsByCategoryAsync(List<NewsCategory> categoryList)
    //    {
    //        if (categoryList != null && categoryList.Any())
    //            return database.QueryAsync<Favorite>($"select * from {nameof(Favorite)} where [CategoryId] = {categoryList.FirstOrDefault().Id}");
    //        return null;
    //    }

    //    public Task<Favorite> GetItemAsync(int id) => database.Table<Favorite>().Where(f => f.Id == id).FirstOrDefaultAsync();

    //    public Task<NewsCategory> GetCategoryAsync(string title) => database.Table<NewsCategory>().Where(c => c.Title.Equals(title)).FirstOrDefaultAsync();

    //    public Task<int> SaveCategoriesAsync(List<NewsCategory> list) => database.InsertAllAsync(list);

    //    public Task<int> SaveCategoryAsync(NewsCategory newsCategory)
    //    {
    //        if (newsCategory.Id == 0)
    //            return database.InsertAsync(newsCategory);
    //        return database.UpdateAsync(newsCategory);
    //    }

    //    public Task<int> SaveItemAsync(Favorite favorite)
    //    {
    //        if (favorite.Id == 0)
    //            return database.InsertAsync(favorite);
    //        return database.UpdateAsync(favorite);
    //    }

    //    public Task<int> DeleteItemAsync(Favorite favorite) => database.DeleteAsync(item: favorite);

    }
}

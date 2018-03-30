using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinMastering.Data
{
    public class Favorite
    {
        string id;
        string title;
        string description;
        string imageUrl;
        DateTime articleDate;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "title")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        [JsonProperty(PropertyName = "description")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }

        [JsonProperty(PropertyName = "articleDate")]
        public DateTime ArticleDate
        {
            get { return articleDate; }
            set { articleDate = value; }
        }

        [Version]
        public string Version { get; set; }
    }

    //public class Favorite
    //{
    //    [SQLite.PrimaryKey, SQLite.AutoIncrement]
    //    public int Id { get; set; }
    //    [SQLite.Ignore]
    //    public NewsCategory Category { get; set; }
    //    public int CategoryId { get; set; }
    //    [SQLite.MaxLength(64)]
    //    public string Title { get; set; }
    //    public string Description { get; set; }
    //    public string ImageUrl { get; set; }
    //    public DateTime ArticleDate { get; set; }
    //}


    //public class NewsCategory
    //{
    //    [SQLite.PrimaryKey, SQLite.AutoIncrement]
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    [SQLite.Ignore]
    //    public string InternalName { get; set; }
    //}
}

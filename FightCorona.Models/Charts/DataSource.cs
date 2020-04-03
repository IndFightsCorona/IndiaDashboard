using System.Collections.Generic;

namespace FightCorona.Models.Charts
{
    public class DataSource
    {
        public Chart Chart { get; set; }
        public List<CategoriesItem> Categories { get; set; }
        public List<Series> Dataset { get; set; }
        public List<Datum> Data { get; set; }
    }

    public class CategoriesItem
    {
        public List<CategoryItem> Category { get; set; }
    }

    public class CategoryItem
    {
        public string Label { get; set; }
    }

    public class Datum
    {
        public string Label { get; set; }
        public int Value { get; set; }
    }

    public class Series
    {
        public string Seriesname { get; set; }
        public List<Datum> Data { get; set; }
        public string Color { get; set; }
        public string ShowValues { get; set; }
    }
}

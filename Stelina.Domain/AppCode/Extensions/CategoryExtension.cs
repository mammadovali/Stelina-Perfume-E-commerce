﻿using Stelina.Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stelina.Domain.AppCode.Extensions
{
    static public partial class Extension
    {
        static public string GetCategoriesRaw(this ICollection<Category> categories)
        {
            if (categories == null || !categories.Any())
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("<ul class='list-categories'>");

            foreach (var category in categories)
            {


                FillCategoriesRaw(category);
                
                
            }

            sb.Append("</ul>");

            return sb.ToString();

            void FillCategoriesRaw(Category category)
            {
                sb.Append("<li class='list-category-item'>");

                if (category.Children.Count == 0 && !category.Children.Any())
                {
                    sb.Append($"<input type='checkbox' id='cb-{category.Id}' />");
                }

                sb.Append($"<label for='cb-@item.Id' class='label-text-category'>{category.Name}</label>");

                if (category.Children.Count != 0 && category.Children.Any())
                {
                    sb.Append($"<i class='fa fa-chevron-down show-children show-children-{category.Id}' data-btn-id='{category.Id}'></i>");
                    sb.Append($"<ul class='children-categories ul-{category.Id}' style='display: none;' data-id='{category.Id}'>");

                    foreach (var child in category.Children)
                    {
                        FillCategoriesRaw(child);
                    }

                    sb.Append("</ul>");
                }

                sb.Append("</li>");
            }
        }

        static public IEnumerable<Category> GetAllChildren(this Category category)
        {
            if (category.ParentId != null)
            {
                yield return category;
            }


            if (category.Children != null)
            {
                foreach (var item in category.Children.SelectMany(c => c.GetAllChildren()))
                {
                    yield return item;
                }
            }


        }
    }
}

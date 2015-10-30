using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtest.Models
{
    public class CourseCategoryModel
    {

        public class CourseCategory
        {
            public int CourseCategoryId { get; set; }

            public string CourseCategoryName { set; get; }
        }


        public class CourseCategoryList
        {
            public List<CourseCategory> CourseCategories { get; set; }
        }

    }

}

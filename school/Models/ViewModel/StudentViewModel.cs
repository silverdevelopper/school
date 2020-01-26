using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school.Models.ViewModel
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Classe> Classes { get; set; }
        public IEnumerable<SelectListItem> CSelectListItem(IEnumerable<Classe> Items)
        {
            List<SelectListItem> ClassList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "---Select--",
                Value = "0",
            };
            ClassList.Add(sli);
            foreach (Classe classe in Items)
            {
                sli = new SelectListItem
                {
                    Text=classe.name,
                    Value=classe.id.ToString()
                };
                ClassList.Add(sli);
            }
            return ClassList;
        }
    }
}

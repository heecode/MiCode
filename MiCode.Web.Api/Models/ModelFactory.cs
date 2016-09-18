using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiCode.Core.Domain;

namespace MiCode.Web.Api.Models
{
    public class ModelFactory
    {
        public SchoolModel Create(School school)
        {
            var schoolModel = new SchoolModel
            {
                Id = school.Id,
                Name = school.Name
            };
            return schoolModel;
        }
        public School Create(SchoolModel schoolModel)
        {
            var school = new School
            {
                Id = schoolModel.Id,
                Name = schoolModel.Name
            };
            return school;
        }
    }
}
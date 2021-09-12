using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DropdownTest.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Honduras",
                    Departments = new List<Department>
                    {
                        new Department
                        {
                            Name = "Francisco Morazán",

                        },
                        new Department
                        {
                            Name = "Cortés",

                        },
                        new Department
                        {
                            Name = "Comayagua",

                        }
                    }
                });
                _context.Countries.Add(new Country
                {
                    Name = "USA",
                    Departments = new List<Department>
                    {
                        new Department
                        {
                            Name = "California",

                        },
                        new Department
                        {
                            Name = "Illinois",

                        }
                    }
                });
                await _context.SaveChangesAsync();
            }

        }
    }
}

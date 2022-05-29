using Microsoft.Extensions.Caching.Memory;

namespace DataAccessLibrary
{
    public class SampleDataAccess
    {
        private readonly IMemoryCache memoryCache;

        public SampleDataAccess(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = new()
            {
                new() { FirstName = "David", LastName = "Callay" },
                new() { FirstName = "John", LastName = "Doe" },
                new() { FirstName = "Sue", LastName = "Cucumber" }
            };

            var etst = string.Empty;
            // comment added

            Thread.Sleep(3000);

            return employees;
        }

        public async Task<List<EmployeeModel>> GetEmployeesAsync()
        {
            List<EmployeeModel> employees = new()
            {
                new() { FirstName = "David", LastName = "Callay" },
                new() { FirstName = "John", LastName = "Doe" },
                new() { FirstName = "Sue", LastName = "Cucumber" }
            };

            await Task.Delay(3000);

            return employees;
        }

        public async Task<List<EmployeeModel>> GetEmployeesCache()
        {
            List<EmployeeModel> employees;

            employees = memoryCache.Get<List<EmployeeModel>>("employees");

            if(employees is null)
            {
                employees = new()
                {
                    new() { FirstName = "David", LastName = "Callay" },
                    new() { FirstName = "John", LastName = "Doe" },
                    new() { FirstName = "Sue", LastName = "Cucumber" }
                };

                await Task.Delay(3000);

                memoryCache.Set("employees", employees, TimeSpan.FromMinutes(1));
            }

            return employees;
        }
    }
}

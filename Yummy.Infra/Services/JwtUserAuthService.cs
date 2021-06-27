using Dapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Yummy.Core.Common;
using Yummy.Core.Data;
using Yummy.Core.Services;
using Yummy.Infra.Common;

namespace Yummy.Infra.Services
{
    public class JwtUserAuthService : IJwtUserAuthService
    {
        private readonly IDBContext DBContext;
        public string EmployeeAuthenticate(Employee employee )
        {
            IEnumerable<Employee> result = DBContext.Connection.Query<Employee>("GetAllEmployee", commandType: CommandType.StoredProcedure);
            result = result.ToList();
            var user = result.SingleOrDefault(x => x.UserName == employee.UserName && x.password == employee.password);

            // return null if user not found
            if (user == null)
                // return BadRequest(new { message = "Username or password is incorrect" });
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, employee.UserName),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Call Center"),
                new Claim(ClaimTypes.Role, "Accountant"),
                new Claim(ClaimTypes.Role, "Delivery")
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);


        }
        public string CustomerAuthenticate(Customer customer)
        {
            IEnumerable<Customer> result = DBContext.Connection.Query<Customer>("GetAllCustomer", commandType: CommandType.StoredProcedure);
            result = result.ToList();
            var user = result.SingleOrDefault(x => x.UserName == customer.UserName && x.Password == customer.Password);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, customer.UserName),
                new Claim(ClaimTypes.Role, "Customer"),
      
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}


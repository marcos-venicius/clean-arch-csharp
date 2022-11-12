﻿using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image) : this(name, description, price, stock, image)
        {
            DomainExceptionValidation.When(id <= 0, "Invalid id value");

            Id = id;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image, categoryId);
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description), "Invalid description. Description is required");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description. minimum 5 characters");

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(image is not null && image.Length > 250, "Invalid image name. too long, maximum 250 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);

            DomainExceptionValidation.When(categoryId <= 0, "Invalid category id");

            CategoryId = categoryId;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

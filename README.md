# 🗃️ Inventory Management System

A simple desktop application for managing inventory, built using **WPF (C#)**. It features product registration, editing, profit tracking, and a secure **login/register system** with user data stored in a `.txt` file.

---

## 🔧 Technologies Used

- .NET 7.0
- WPF (Windows Presentation Foundation)
- C#
- StreamReader / StreamWriter for File I/O

---

## 🧩 Features

### 🔐 Authentication

- Register new users
- Login with a 3-attempt limit (account locks after 3 failed attempts)
- User credentials stored in `users.txt`
- Duplicate username check

### 📦 Product Management

- Add new products
- Edit or delete existing products
- Track category, description, purchase/selling price, and quantity
- Profit calculation:  
  **Profit = (Selling Price - Purchase Price) × Quantity**

### 📊 Profit Report

- View a table showing:
  - Product Name
  - Total Profit
- *(✔ Optional: extend with charts later)*

---

## 📁 Project Structure

```plaintext
InventorySystem/
│
├── login/                 # Login and registration logic
├── model/                 # Classes like Product, User
├── view/                  # WPF XAML views
├── ProductRepository.cs   # Central product storage (ObservableCollection)
└── users.txt              # Stored user accounts

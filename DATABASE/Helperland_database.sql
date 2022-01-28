Create database Helperland_Database

Use Helperland_Database
go

Create Schema Helperland_Data
go

Create Table Helperland_Data.UserType
(
	User_type_Id int identity(1,1) primary key NOT NULL,
	User_type_Name nvarchar(20) NOT NULL,
)

Create Table Helperland_Data.Customer
(
	Customer_Id int identity(1,1) primary key NOT NULL,
	First_Name nvarchar(20) NOT NULL,
	Last_Name varchar(20) NOT NULL,
	Email varchar(20) NOT NULL,
	Mobile_Number nvarchar(20) NOT NULL,
	Password nvarchar(20) NOT NULL,
	User_Type_Id int foreign key references Helperland_Data.UserType(User_type_Id) NOT NULL,
	Date_Of_Birth date NULL,
	Language varchar(30) NOT NULL,
)

Create Table Helperland_Data.Service_Provider
(
	Service_Provider_Id int identity(1,1) primary key NOT NULL,
	First_Name varchar(20) NOT NULL,
	Last_Name varchar(20) NOT NULL,
	Email varchar(20) NOT NULL,
	CONSTRAINT sp_Email UNIQUE(Email),
	Mobile_Number varchar(20) NOT NULL,
	Password varchar(20) NOT NULL,
	Date_Of_Birth date NULL,
	Nationality char(20) NOT NULL,
	Gender char(10) NOT NULL,
	Avtar varbinary(50) NULL,
	Street_Name varchar(50) NOT NULL,
	House_Number varchar(50) NOT NULL,
	PostalCode int NOT NULL,
	City char(20) NOT NULL,
	User_Type_Id int foreign key references Helperland_Data.UserType(User_type_Id) NOT NULL,
)

Create Table Helperland_Data.BookService
(
	Service_Id int identity(1,1) primary key NOT NULL,
	Service_Date date NOT NULL,
	Service_Time time(7) NOT NULL,
	Total_Service_Duration time(7) NOT NULL,
	No_Of_Extra_Services int NULL,
	Discount float NOT NULL,
	Total_Payment float NOT NULL,
	Grand_Payment float NOT NULL,
	Service_Provider_Id int foreign key references Helperland_Data.Service_Provider(Service_Provider_Id) NOT NULL,
	pet bit NULL,
)

Create Table Helperland_Data.Customer_Details
(
	Service_Details_Id int identity(1,1) primary key NOT NULL, 
	Service_Id int foreign key references Helperland_Data.BookService(Service_Id) NOT NULL,
	Street_Name varchar(20) NOT NULL,
	Postal_Code varchar(6) NOT NULL,
	City varchar(20) NOT NULL,
	Phone_Number varchar(20) NOT NULL,
	Favourite_Service_Provider varchar(30) NULL,
	House_Number varchar(30) NULL
)

Create Table Helperland_Data.ContactUs
(
	First_Name varchar(20) NOT NULL,
	Last_Name varchar(20) NOT NULL,
	Email varchar(20) NOT NULL,
	CONSTRAINT contactus_Email UNIQUE(Email),
	Phone_Number varchar(20) NOT NULL,
	Subject varchar(20) NOT NULL,
	Message varchar(100) NULL,
)

Create Table Helperland_Data.BlockCustomer
(
	Block_Id int identity(1,1) primary key NOT NULL,
	Customer_Id int foreign key references Helperland_Data.Customer(Customer_Id) NOT NULL,
)

Create Table Helperland_Data.Rate_Service_Provider
(
	Rate_Id int identity(1,1) primary key NOT NULL,
	Rating float NULL,
	Customer_Id int foreign key references Helperland_Data.Customer(Customer_Id) NOT NULL,
	Service_Provider_Id int foreign key references Helperland_Data.Service_Provider(Service_Provider_Id) NOT NULL,
	Service_Id int foreign key references Helperland_Data.BookService(Service_Id) NOT NULL,
	Freindly [float] NULL,
	Time_Arrival float NULL,
	Quality_Of_Service float NULL,
	Feedback varchar(100) NULL,
)

Create Table Helperland_Data.Newsletter
(
	Email varchar(20) NULL,
	CONSTRAINT newsletter_Email UNIQUE(Email),
	Newsletter_Id int identity(1,1) primary key NOT NULL,
)

    
-- CREATE DATABASE FahasaStoreDB;
-- USE FahasaStoreDB

-- Tạo bảng Website 
CREATE TABLE Website (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100) NOT NULL,
    logo_url NVARCHAR(MAX) NOT NULL,
    icon_url NVARCHAR(MAX) NOT NULL,
    description NVARCHAR(255) NOT NULL,
    address NVARCHAR(255) NOT NULL,
    phone NVARCHAR(20) NOT NULL,
    email NVARCHAR(100) NOT NULL,
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Banners
CREATE TABLE Banners (
    id INT PRIMARY KEY IDENTITY(1,1),
	public_id NVARCHAR(MAX),
    image_url NVARCHAR(MAX),
    title NVARCHAR(255) NOT NULL,
    content NVARCHAR(MAX) NOT NULL,
    created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Menu
CREATE TABLE Menu (
    id INT PRIMARY KEY IDENTITY(1,1),
	name NVARCHAR(255) NOT NULL UNIQUE,
    link NVARCHAR(MAX) NOT NULL,
    public_id NVARCHAR(MAX),
    image_url NVARCHAR(MAX),
	created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE Vouchers (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) NOT NULL,
    code NVARCHAR(100) NOT NULL UNIQUE,
    description NVARCHAR(255),
    discount_percent INT NOT NULL CHECK (discount_percent >= 0 AND discount_percent <= 100),
    start_date DATETIME NOT NULL,
    end_date DATETIME NOT NULL,
    min_order_amount INT NOT NULL CHECK (min_order_amount >= 0),
    max_discount_amount INT NOT NULL CHECK (max_discount_amount >= 0),
    usage_limit INT NOT NULL CHECK (usage_limit >= 0),
	CHECK (start_date <= end_date),
	created_at DATETIME DEFAULT GETDATE()
);


-- Tạo bảng Topics
CREATE TABLE Topics (
    id INT PRIMARY KEY IDENTITY(1,1),
    topic_name NVARCHAR(255) NOT NULL UNIQUE,
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng HelpContents
CREATE TABLE TopicContents (
    id INT PRIMARY KEY IDENTITY(1,1),
    topic_id INT NOT NULL FOREIGN KEY REFERENCES Topics(id),
    title NVARCHAR(255) NOT NULL UNIQUE,
    content NVARCHAR(MAX) NOT NULL,
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng platforms
CREATE TABLE Platforms (
    id INT PRIMARY KEY IDENTITY(1,1),
    platform_name NVARCHAR(50) NOT NULL UNIQUE,
	public_id NVARCHAR(MAX),
    image_url NVARCHAR(MAX),
    link NVARCHAR(MAX) NOT NULL,
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Categories
CREATE TABLE Categories (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(50) NOT NULL UNIQUE,
	public_id NVARCHAR(MAX),
    image_url NVARCHAR(MAX),
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Subcategories
CREATE TABLE Subcategories (
    id INT PRIMARY KEY IDENTITY(1,1),
    category_id INT NOT NULL FOREIGN KEY REFERENCES Categories(id),
    name NVARCHAR(50) NOT NULL UNIQUE,
	public_id NVARCHAR(MAX),
    image_url NVARCHAR(MAX),
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng PartnerTypes
CREATE TABLE PartnerTypes (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100) NOT NULL UNIQUE,
	created_at DATETIME DEFAULT GETDATE()
)

-- Tạo bảng Partners
CREATE TABLE Partners (
    id INT PRIMARY KEY IDENTITY(1,1),
	partner_type_id INT NOT NULL FOREIGN KEY REFERENCES PartnerTypes(id),
    name NVARCHAR(100) NOT NULL,
    address NVARCHAR(255) NOT NULL,
    phone NVARCHAR(20) NOT NULL,
    email NVARCHAR(100) NOT NULL,
	public_id NVARCHAR(MAX),
	image_url NVARCHAR(MAX),
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Authors
CREATE TABLE Authors (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100) NOT NULL,
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng CoverTypes
CREATE TABLE CoverTypes (
    id INT PRIMARY KEY IDENTITY(1,1),
    type_name NVARCHAR(50) NOT NULL UNIQUE,
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Dimensions
CREATE TABLE Dimensions (
    id INT PRIMARY KEY IDENTITY(1,1),
    length INT NOT NULL CHECK (length > 0),
    width INT NOT NULL CHECK (width > 0),
    height INT NOT NULL CHECK (height > 0),
	unit NVARCHAR(10) NOT NULL,
	UNIQUE (length, width, height, unit),
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Books
CREATE TABLE Books (
    id INT PRIMARY KEY IDENTITY(1,1),
    subcategory_id INT NOT NULL FOREIGN KEY REFERENCES Subcategories(id),
    author_id INT NOT NULL FOREIGN KEY REFERENCES Authors(id),
    cover_type_id INT NOT NULL FOREIGN KEY REFERENCES CoverTypes(id),
    dimension_id INT NOT NULL FOREIGN KEY REFERENCES Dimensions(id),
    name NVARCHAR(255) NOT NULL,
    description NVARCHAR(MAX) NOT NULL,
    price INT NOT NULL CHECK (price >= 0),
    discount_percentage INT NOT NULL CHECK (discount_percentage >= 0 AND discount_percentage <= 100),
    quantity INT NOT NULL CHECK (quantity >= 0),
    weight FLOAT CHECK (weight > 0),
    page_count INT CHECK (page_count > 0),
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng BookPartners
CREATE TABLE BookPartners (
	id INT PRIMARY KEY IDENTITY(1,1),
	book_id INT NOT NULL FOREIGN KEY REFERENCES Books(id),
	partner_id INT NOT NULL FOREIGN KEY REFERENCES Partners(id),
    note NVARCHAR(50),
	UNIQUE (book_id, partner_id),
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng PosterImages
CREATE TABLE PosterImages (
    id INT PRIMARY KEY IDENTITY(1,1),
	book_id INT NOT NULL FOREIGN KEY REFERENCES Books(id),
	public_id NVARCHAR(MAX),
    image_url NVARCHAR(MAX),
	image_default BIT NOT NULL,
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng FlashSales
CREATE TABLE FlashSales (
    id INT PRIMARY KEY IDENTITY(1,1),
    start_date DATETIME NOT NULL,
    end_date DATETIME NOT NULL,
	CHECK (end_date > start_date),
	created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE FlashSaleBooks (
	id INT PRIMARY KEY IDENTITY(1,1),
    flash_sale_id INT NOT NULL FOREIGN KEY REFERENCES FlashSales(id),
    book_id INT NOT NULL FOREIGN KEY REFERENCES Books(id),
    discount_percentage INT NOT NULL CHECK (discount_percentage >= 0 AND discount_percentage <= 100),
	quantity INT NOT NULL CHECK (quantity >= 0),
	UNIQUE (flash_sale_id, book_id),
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Address
CREATE TABLE Address (
    id INT PRIMARY KEY IDENTITY(1,1),
    user_id NVARCHAR(450) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(id),
	receiver_name NVARCHAR(50) NOT NULL,
	phone NVARCHAR(20) NOT NULL,
    province NVARCHAR(50) NOT NULL,
    district NVARCHAR(50) NOT NULL,
    ward NVARCHAR(50) NOT NULL,
    detail NVARCHAR(255) NOT NULL,
    default_address BIT NOT NULL,
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng PaymentMethods
CREATE TABLE PaymentMethods (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(50) NOT NULL UNIQUE,
	public_id NVARCHAR(MAX),
    image_url NVARCHAR(MAX),
	active BIT NOT NULL,
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Status
CREATE TABLE Status (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(50) NOT NULL UNIQUE,
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Orders
CREATE TABLE Orders (
    id INT PRIMARY KEY IDENTITY(1,1),
    user_id NVARCHAR(450) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(id),
	voucher_id INT FOREIGN KEY REFERENCES Vouchers(id),
	address_id INT NOT NULL FOREIGN KEY REFERENCES Address(id),
	payment_method_id INT NOT NULL FOREIGN KEY REFERENCES PaymentMethods(id),
	note NVARCHAR(50),
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng OrderItems
CREATE TABLE OrderItems (
	id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT NOT NULL FOREIGN KEY REFERENCES Orders(id),
    book_id INT NOT NULL FOREIGN KEY REFERENCES Books(id),
    quantity INT NOT NULL CHECK (quantity > 0),
	price INT CHECK (price >= 0),
    discount_percentage INT CHECK (discount_percentage >= 0 AND discount_percentage <= 100),
	UNIQUE (order_id, book_id),
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng OrderStatus
CREATE TABLE OrderStatus (
	id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT NOT NULL FOREIGN KEY REFERENCES Orders(id),
    status_id INT NOT NULL FOREIGN KEY REFERENCES Status(id),
	UNIQUE (order_id, status_id),
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Payments
CREATE TABLE Payments (
	id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT NOT NULL UNIQUE FOREIGN KEY REFERENCES Orders(id),
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Reviews
CREATE TABLE Reviews (
	id INT PRIMARY KEY IDENTITY(1,1),
    book_id INT NOT NULL FOREIGN KEY REFERENCES Books(id),
    order_id INT NOT NULL FOREIGN KEY REFERENCES Orders(id),
    user_id NVARCHAR(450) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(id),
    rating INT NOT NULL CHECK (rating >= 1 AND rating <= 5),
    comment NVARCHAR(250),
	active BIT NOT NULL,
	UNIQUE (book_id, order_id, user_id),
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Carts
CREATE TABLE Carts (
    id INT PRIMARY KEY IDENTITY(1,1),
    user_id NVARCHAR(450) NOT NULL UNIQUE FOREIGN KEY REFERENCES AspNetUsers(id),
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng CartItems
CREATE TABLE CartItems (
	id INT PRIMARY KEY IDENTITY(1,1),
    cart_id INT NOT NULL FOREIGN KEY REFERENCES Carts(id),
    book_id INT NOT NULL FOREIGN KEY REFERENCES Books(id),
    quantity INT NOT NULL CHECK (quantity > 0),
	UNIQUE (cart_id, book_id),
	created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE NotificationTypes (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255) NOT NULL UNIQUE,
	created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE Notifications (
    id INT PRIMARY KEY IDENTITY(1,1),
	notification_type_id INT NOT NULL FOREIGN KEY REFERENCES NotificationTypes(id),
	user_id NVARCHAR(450) FOREIGN KEY REFERENCES AspNetUsers(id),
    title NVARCHAR(255) NOT NULL,
    content NVARCHAR(255) NOT NULL,
	is_read BIT NOT NULL,
	created_at DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Favourites
CREATE TABLE Favourites (
	id INT PRIMARY KEY IDENTITY(1,1),
    user_id NVARCHAR(450) NOT NULL FOREIGN KEY REFERENCES AspNetUsers(id),
    book_id INT NOT NULL FOREIGN KEY REFERENCES Books(id),
	UNIQUE (user_id, book_id),
	created_at DATETIME DEFAULT GETDATE()
);
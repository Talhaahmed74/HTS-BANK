CREATE DATABASE HTS_BANK_FINAL
USE HTS_BANK_FINAL


--ADMIN TABLE--
CREATE TABLE Admins(
    Admin_Id INT IDENTITY(9000,1) PRIMARY KEY,
    Admin_Password VARCHAR(255) NOT NULL 
);

--BRANCH TABLE--
CREATE TABLE Branch(
    Branch_Id INT IDENTITY(3000,1) PRIMARY KEY,
    Branch_Address VARCHAR(255),
    Branch_PhoneNo VARCHAR(11),
    Admin_Id INT,
    FOREIGN KEY (Admin_Id) REFERENCES Admins(Admin_Id),
	CONSTRAINT CHECK_PHONE_NO CHECK (
        LEN(Branch_PhoneNo) = 11 AND
        Branch_PhoneNo LIKE '[0-9]%')
);

	--ACCOUNT TABLE--
	CREATE TABLE Accounts(
		Account_No INT IDENTITY(10001,1) PRIMARY KEY,
		Account_Password VARCHAR(255) NOT NULL, 
		Account_CreatedAt DATETIME,
		Account_Balance MONEY,
		Account_First_Name VARCHAR(120),
		Account_Last_Name VARCHAR(120),
		Account_CNIC VARCHAR(15),  
		Account_Age INT,
		Account_Email VARCHAR(50),
		Account_Address VARCHAR(120),
		Branch_Id INT, 
		Admin_Id INT,
		CONSTRAINT CHK_NoIntegerInName CHECK (Account_First_Name NOT LIKE '%[0-9]%' AND Account_Last_Name NOT LIKE '%[0-9]%'),
		CONSTRAINT CHECK_EMAIL CHECK (CHARINDEX('@', Account_Email) > 0),
		CONSTRAINT CHECK_AGE CHECK (Account_Age > 18),
		CONSTRAINT CHECK_CNIC CHECK (LEN(Account_CNIC) = 13),
		FOREIGN KEY (Branch_Id) REFERENCES Branch(Branch_Id),
		FOREIGN KEY (Admin_Id) REFERENCES Admins(Admin_Id)
	);

	--ALTEERATION--
	ALTER TABLE Accounts 
	ADD Account_Gender varchar(125), 
	Account_Father_Name varchar(122);
	ALTER TABLE Accounts ADD Account_Type varchar(111);
	ALTER TABLE Accounts ADD Account_PhoneNumber varchar(111);
	ALTER TABLE Accounts ADD IsPakistani varchar(111);

 

--BRANCH ASSOCIATION TABLE--
CREATE TABLE Branch_Association (
    Association_ID INT IDENTITY(1,1) PRIMARY KEY,
    Account_No INT,
    Branch_Id INT,
    FOREIGN KEY (Account_No) REFERENCES Accounts(Account_No),
    FOREIGN KEY (Branch_Id) REFERENCES Branch(Branch_Id)
);	
/*
--CUSTOMER TABLE--
CREATE TABLE Customer (
    Customer_ID INT IDENTITY(1,1) PRIMARY KEY,
    Customer_PhoneNumber VARCHAR(11) NOT NULL,
    Account_No INT,
    FOREIGN KEY (Account_No) REFERENCES Accounts(Account_No),
	CONSTRAINT CHECK_Customer_PHONE_NO CHECK (
        LEN(Customer_PhoneNumber) = 11 AND
        Customer_PhoneNumber LIKE '[0-9]%')
);
*/
--WITHDRAWAL TABLE--

--DEPOSIT TABLE--
CREATE TABLE Deposit (
    Deposit_ID INT IDENTITY(100,1) PRIMARY KEY,
	Deposited_By INT,
	Receiver INT,
    Account_No INT,
    Deposit_Amount MONEY,
    Deposit_Date DATETIME,
    FOREIGN KEY (Account_No) REFERENCES Accounts(Account_No)
);
ALTER TABLE Deposit 
ADD Deposit_Status VARCHAR(255)


--BILLPAYMENT TABLE
CREATE TABLE BillPayment (
    BillPayment_ID INT IDENTITY(2000,1) PRIMARY KEY,
    Account_No INT,
    Bill_Type VARCHAR(50),
    Bill_Amount MONEY,
    Payment_Date DATETIME,
    FOREIGN KEY (Account_No) REFERENCES Accounts(Account_No)
);

--TRANSACTION_HISTORY TABLE
CREATE TABLE Transaction_History (
    Transaction_ID INT IDENTITY(10,1) PRIMARY KEY,
    Receiver_Account_Id INT,
	Sender_Account_Id INT,
    Transaction_Type VARCHAR(50), 
    Amount MONEY,
    Transaction_Date DATETIME,
);
ALTER TABLE Transaction_History
ADD transaction_status VARCHAR(255)


CREATE TABLE Balance (
    Balance_ID INT PRIMARY KEY IDENTITY(1,1),
    Account_No INT,
    Current_Balance MONEY,
    Remaining_Data_MB DECIMAL(10, 2),
    Remaining_SMS INT,
    Remaining_Minutes INT,
    FOREIGN KEY (Account_No) REFERENCES Accounts(Account_No)
);

INSERT INTO Balance (Current_Balance)
	WHERE Account_N0 = 10013 


--------------------------------------Procedures-----------------------------------------------------------------

--Login Procedure--
CREATE PROCEDURE Login_Account 
	@Account_No INT , 
	@Account_Password VARCHAR(255)
AS
BEGIN
	SELECT Account_No , Account_Password FROM Accounts WHERE Account_No = @Account_No
END;


--Admin login Procedure--
CREATE PROCEDURE Admin_Login_Account 
	@Admin_Id INT , 
	@Admin_Password VARCHAR(255)
AS
BEGIN
	SELECT Admin_Id , Admin_Password FROM Admins WHERE Admin_Id = @Admin_Id
END;


--BillInfo Procedure--
CREATE PROCEDURE Get_Bill_Info 
	@BillPayment_Id INT
AS 
BEGIN
	SELECT Account_No , BillPayment_ID , Bill_Type , Bill_Amount
	FROM BillPayment 
	WHERE BillPayment_Id = @BillPayment_Id	
END

--CheckIfCnicExists

CREATE PROCEDURE [dbo].[CheckIfCnicExists]
		@cnic NVARCHAR(20),
		@cnicExists BIT OUTPUT
	AS
	BEGIN
	    SET NOCOUNT ON;

	    IF EXISTS (SELECT 1 FROM Accounts WHERE Account_CNIC = @cnic)
	        SET @cnicExists = 1;
	    ELSE
	        SET @cnicExists = 0;
	END;



--SIGNUP PROCEDURE--
ALTER PROCEDURE spSignup
    @firstName NVARCHAR(120),
    @lastName NVARCHAR(120),
    @fatherName NVARCHAR(122),
    @age INT,
	@gender VARCHAR(255),
    @phoneNumber VARCHAR(11),
    @address NVARCHAR(255),
    @cnic VARCHAR(15),
	@email VARCHAR(255),
    @accountType VARCHAR(111),
    @password VARCHAR(255),
    @branchId INT,
    @adminId INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @newAccountId INT;

    -- Inserting into Accounts table
    INSERT INTO Accounts (
        Account_Password,
        Account_CreatedAt,
        Account_Balance,
        Account_First_Name,
        Account_Last_Name,
		Account_Father_Name,
        Account_CNIC,
		Account_Email,
        Account_Age,
		Account_Gender,
        Account_Address,
        Branch_Id,
        Admin_Id,
        Account_Type,
        Account_PhoneNumber
    )
    VALUES (
        @password,
        GETDATE(),
        0.0,  -- Assuming initial balance is 0
        @firstName,
        @lastName,
		@fatherName,
        @cnic,
		@email,
        @age,
		@gender,
        @address,
        @branchId,
        @adminId,
        @accountType,
        @phoneNumber
    );

    -- Retrieving the newly inserted Account_No
    SELECT @newAccountId = SCOPE_IDENTITY();

    -- Inserting into Branch_Association table
    INSERT INTO Branch_Association (Account_No, Branch_Id)
    VALUES (@newAccountId, @branchId);

    -- Returning the newly created Account_No
    SELECT @newAccountId AS NewAccountId;
END;


    -- Retrieving the newly inserted Account_No
    SELECT @newAccountId = SCOPE_IDENTITY();

    -- Inserting into Branch_Association table
    INSERT INTO Branch_Association (Account_No, Branch_Id)
    VALUES (@newAccountId, @branchId);

    -- Returning the newly created Account_No
    SELECT @newAccountId AS NewAccountId;
END





CREATE PROCEDURE Get_Bill_Details
    @Account_No INT
AS
BEGIN
    -- Retrieve the bill details for the given Account_No
    SELECT * 
    FROM BillPaymentHistoryView 
    WHERE Account_No = @Account_No;
END
EXEC Get_Bill_Details @Account_No = 10014;  


CREATE PROCEDURE TRANSACTION_DETAILS
    @Account_No INT
AS
BEGIN
    SELECT * 
    FROM TransactionHistoryView 
    WHERE Account_No = @Account_No;
CREATE PROCEDURE UpsertBalance 
    @Account_No INT,
    @Current_Balance MONEY,
    @Remaining_Data_MB DECIMAL(10, 2),
    @Remaining_SMS INT,
    @Remaining_Minutes INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Balance WHERE Account_No = @Account_No)
    BEGIN
        -- Update existing balance record
        UPDATE Balance
        SET 
            Current_Balance = @Current_Balance,
            Remaining_Data_MB = @Remaining_Data_MB,
            Remaining_SMS = @Remaining_SMS,
            Remaining_Minutes = @Remaining_Minutes
        WHERE 
            Account_No = @Account_No;
    END
    ELSE
    BEGIN
        -- Insert new balance record
INSERT INTO Balance (
            Account_No,
            Current_Balance,
            Remaining_Data_MB,
            Remaining_SMS,
            Remaining_Minutes
        ) VALUES (
            @Account_No,
            @Current_Balance,
            @Remaining_Data_MB,
            @Remaining_SMS,
            @Remaining_Minutes
        );
    END
END;

-- Insert a new record
EXEC UpsertBalance 
    @Account_No = 10006,
    @Current_Balance = 8000.00,
    @Remaining_Data_MB = 1500.75,
    @Remaining_SMS = 200,
    @Remaining_Minutes = 250;


-----------------------------------------------TRIGGERS-----------------------------------------
CREATE OR ALTER TRIGGER trg_DepositHistory
ON Deposit
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Transaction_History (Receiver_Account_Id, Sender_Account_Id, Transaction_Date, Amount, Transaction_Type ,transaction_status)
    SELECT Receiver, Deposited_By , GETDATE(), Deposit_Amount, 'Deposit' , Deposit_Status
    FROM inserted;
END;


/*
CREATE TRIGGER trg_WithdrawalHistory
ON Withdrawal
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Transaction_History (Account_No, Transaction_Date, Amount, Transaction_Description)
    SELECT Account_No, GETDATE(), Withdrawal_Amount, 'Withdrawal'
    FROM inserted;
END;
*/



EXEC spSignup 
    @firstName = 'John',
    @lastName = 'Doe',
    @fatherName = 'Michael Doe',
    @age = 25,
    @phoneNumber = '123-456-7890',
    @address = '123 Main St, Anytown, USA',
    @cnic = '1234567890115',  -- Optional, you can pass NULL if not applicable
    @password = 'securepassword123',
    @accountType = 'Saving';
SELECT * FROM Accounts

-- Insert data into 'Accounts' table
INSERT INTO Accounts (
    Account_Password, 
    Account_CreatedAt, 
    Account_Balance, 
    Account_First_Name, 
    Account_Last_Name, 
    Account_CNIC, 
    Account_Age, 
    Account_Email, 
    Account_Address, 
    Branch_Id, 
    Admin_Id,
    Account_Gender,
    Account_Father_Name,
    Account_Type,
    Account_PhoneNumber,
    IsPakistani
) VALUES
(
    'password789', 
    GETDATE(), 
    20000.00, 
    'Alice', 
    'Johnson', 
    '3456789012345', 
    28, 
    'alice.johnson@example.com', 
    '789 Pine Road', 
    3001, 
    9004, 
    'Female',
    'Michael Johnson',
    'Savings',
    3456789012,
    1
),
(
    'password123', 
    GETDATE(), 
    15000.00, 
    'Bob', 
    'Smith', 
    '4567890123456', 
    32, 
    'bob.smith@example.com', 
    '123 Oak Street', 
    3004, 
    9006, 
    'Male',
    'Robert Smith',
    'Checking',
    4567890123,
    1
),
(
    'password456', 
    GETDATE(), 
    25000.00, 
    'Carol', 
    'White', 
    '5678901234567', 
    45, 
    'carol.white@example.com', 
    '456 Maple Avenue', 
    3002, 
    9001, 
    'Female',
    'John White',
    'Savings',
    5678901234,
    1
),
(
    'password789', 
    GETDATE(), 
    18000.00, 
    'David', 
    'Brown', 
    '6789012345678', 
    29, 
    'david.brown@example.com', 
    '789 Birch Lane', 
    3003, 
    9003, 
    'Male',
    'James Brown',
    'Checking',
    6789012345,
    1
),
(
    'password321', 
    GETDATE(), 
    22000.00, 
    'Emily', 
    'Davis', 
    '7890123456789', 
    34, 
    'emily.davis@example.com', 
    '123 Cedar Street', 
    3001, 
    9004, 
    'Female',
    'Henry Davis',
    'Savings',
    7890123456,
    1
),
(
    'password654', 
    GETDATE(), 
    16000.00, 
    'Frank', 
    'Moore', 
    '8901234567890', 
    40, 
    'frank.moore@example.com', 
    '456 Spruce Road', 
    3003, 
    9005, 
    'Male',
    'Thomas Moore',
    'Checking',
    8901234567,
    1
),
(
    'password987', 
    GETDATE(), 
    27000.00, 
    'Grace', 
    'Taylor', 
    '9012345678901', 
    26, 
    'grace.taylor@example.com', 
    '789 Elm Avenue', 
    3004, 
    9004, 
    'Female',
    'William Taylor',
    'Savings',
    9012345678,
    1
),
(
    'password111', 
    GETDATE(), 
    19000.00, 
    'Hannah', 
    'Harris', 
    '1234567890123', 
    31, 
    'hannah.harris@example.com', 
    '123 Walnut Drive', 
    3003, 
    9006, 
    'Female',
    'Richard Harris',
    'Checking',
    1234567890,
    1
),
(
    'password222', 
    GETDATE(), 
    21000.00, 
    'Ian', 
    'Clark', 
    '2345678901234', 
    27, 
    'ian.clark@example.com', 
    '456 Cherry Street', 
    3001, 
    9001, 
    'Male',
    'Edward Clark',
    'Savings',
    2345678901,
    1
),
(
    'password333', 
    GETDATE(), 
    24000.00, 
    'Julia', 
    'Lewis', 
    '3456789012346', 
    38, 
    'julia.lewis@example.com', 
    '789 Chestnut Road', 
    3003, 
    9003, 
    'Female',
    'Matthew Lewis',
    'Checking',
    3456789013,
    1
),
(
    'password444', 
    GETDATE(), 
    26000.00, 
    'Kyle', 
    'Walker', 
    '4567890123457', 
    33, 
    'kyle.walker@example.com', 
    '123 Willow Lane', 
    3004, 
    9004, 
    'Male',
    'George Walker',
    'Savings',
    4567890124,
    1
);


INSERT INTO Accounts (
    Account_Password, 
    Account_CreatedAt, 
    Account_Balance, 
    Account_First_Name, 
    Account_Last_Name, 
    Account_CNIC, 
    Account_Age, 
    Account_Email, 
    Account_Address, 
    Branch_Id, 
    Admin_Id,
    Account_Gender,
    Account_Father_Name,
    Account_Type,
    Account_PhoneNumber,
    IsPakistani
) VALUES (
    'password789', 
    GETDATE(), 
    20000.00, 
    'Alice', 
    'Johnson', 
    '3456789012345', 
    28, 
    'alice.johnson@example.com', 
    '789 Pine Road', 
    3001, 
    9004, 
    'Female',
    'Michael Johnson',
    'Savings',
    3456789012,
    1
);



INSERT INTO Admins (Admin_Password) VALUES
('admin789'),
('admin001'),
('admin202'),
('admin303'),
('admin404'),
('admin505'),
('admin606');



INSERT INTO Branch (Branch_Address, Branch_PhoneNo, Admin_Id) VALUES
('789 Elm St', '03345678901', 9003),
('101 Oak Blvd', '03456789012', 9004),
('202 Pine Lane', '03567890123', 9005),
('303 Cedar Ave', '03678901234', 9001),
('404 Birch Road', '03789012345', 9002);

SELECT * FROM Accounts

-- Insert sample data into the Transaction_History table
INSERT INTO Transaction_History (Account_No, Transaction_Description, Amount, Transaction_Date)
VALUES 
(10013, 'Grocery Shopping', 150.75, '2024-06-10 14:30:00'),
(10041, 'Electricity Bill', 75.00, '2024-06-09 12:00:00'),
(10032, 'Restaurant Dinner', 45.25, '2024-06-08 19:45:00'),
(10035, 'Monthly Rent', 1200.00, '2024-06-01 09:00:00'),
(10040, 'Gym Membership', 50.00, '2024-06-07 18:00:00');


--Insert sample data into the BillPayment table
INSERT INTO BillPayment (Account_No, Bill_Type, Bill_Amount, Payment_Date)
VALUES 
(10013, 'Electricity', 100.00, '2024-06-01 12:00:00'),
(10035, 'Water', 50.00, '2024-06-02 10:00:00'),
(10036, 'Internet', 75.00, '2024-06-03 14:00:00'),
(10036, 'Phone', 30.00, '2024-06-04 16:00:00'),
(10036, 'Rent', 800.00, '2024-06-05 08:00:00');

INSERT INTO Balance (Account_No, Current_Balance, Remaining_Data_MB, Remaining_SMS, Remaining_Minutes) VALUES
(10013, 5000.00, 1024.50, 50, 100),
(10032, 12000.00, 2048.00, 150, 300),
(10033, 7500.00, 512.25, 30, 75),
(10036, 3200.00, 256.75, 80, 50),
(10040, 9100.00, 1024.00, 60, 200);



----------------------------------VIEWS-------------------------------------

CREATE VIEW BillPaymentHistoryView AS
SELECT
    bp.BillPayment_ID,
    bp.Bill_Type,
    bp.Bill_Amount,
    bp.Payment_Date,
    a.Account_No,
    a.Account_First_Name,
    a.Account_Last_Name,
    a.Account_Email,
    a.Account_PhoneNumber
FROM
    BillPayment bp
JOIN
    Accounts a ON bp.Account_No = a.Account_No;

-- Fetch all records from the view
SELECT * FROM BillPaymentHistoryView 

-- Count the number of records in the view
SELECT COUNT(*) TotalRecords FROM BillPaymentHistoryView;

-- Fetch specific columns
SELECT BillPayment_ID, Account_No, Bill_Amount FROM BillPaymentHistoryView WHERE Bill_Amount > 100;

SELECT * FROM BillPaymentHistoryView WHERE Payment_Date > '2024-06-03';



-- Create the TransactionHistoryView
CREATE VIEW TransactionHistoryView AS
SELECT
    th.Transaction_ID,
    th.Account_No,
    th.Transaction_Description,
    th.Amount,
    th.Transaction_Date,
    a.Account_First_Name,
    a.Account_Last_Name,
    a.Account_Email,
    a.Account_PhoneNumber
FROM
    Transaction_History th
JOIN
    Accounts a ON th.Account_No = a.Account_No;

-- Verification Queries

-- Fetch all records from the view
SELECT * FROM TransactionHistoryView;

-- Count the number of records
SELECT COUNT(*) FROM TransactionHistoryView;

-- Fetch records for a specific account
SELECT * FROM TransactionHistoryView WHERE Account_No = 1;

-- Fetch transactions with amounts greater than a specified value
SELECT * FROM TransactionHistoryView WHERE Amount > 100;

-- Get the sum of amounts grouped by account number
SELECT Account_No, SUM(Amount) AS Total_Amount
FROM TransactionHistoryView
GROUP BY Account_No;


-- Create the AccountBalanceView
CREATE VIEW AccountBalanceView AS
SELECT 
    a.Account_No,
    b.Current_Balance,
    b.Remaining_Data_MB,
    b.Remaining_SMS,
    b.Remaining_Minutes
FROM 
    Accounts a
JOIN 
    Balance b ON a.Account_No = b.Account_No;



SELECT * FROM Balance;
SELECT * FROM BillPaymentHistory;

TRUNCATE TABLE BillPayment
DROP TABLE BillPaymentHistory

--CREATE TABLE BillPaymentHistory(
--	BillHistory_ID INT IDENTITY(10,1) PRIMARY KEY,
--	Account_Id INT,
--    Bill_Type VARCHAR(50), 
--    Amount MONEY,
--    Payment_Date DATETIME,
--	Bill_Status VARCHAR(50),
--	 FOREIGN KEY (Account_Id) REFERENCES Accounts(Account_No)
--);

CREATE TABLE BillPayment (
    BillPayment_ID INT IDENTITY(2000,1) PRIMARY KEY,
    Account_No INT,
    Bill_Type VARCHAR(50),
    Bill_Amount MONEY,
    Payment_Date DATETIME,
    FOREIGN KEY (Account_No) REFERENCES Accounts(Account_No)
);

CREATE OR ALTER TRIGGER trg_BillPaymentHistory
ON BillPayment
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
	IF UPDATE(IsPaid)
    BEGIN
		INSERT INTO Transaction_History (Receiver_Account_Id, Sender_Account_Id, Transaction_Date, Amount, Transaction_Type ,transaction_status)
		SELECT NULL, Account_No , GETDATE(), Bill_Amount, 'Bill Payment' , 'Paid'
		FROM inserted;
	END
END;

--Request Info Update

CREATE TABLE AccountInfoUpdateRequests 
(
	AccountNumber INT NOT NULL ,
	RequestDescription NVARCHAR(255) NOT NULL
)

DROP TABLE AccountInfoUpdateRequests

--it works when i write liek this | one row result
SELECT 
aiur.AccountNumber ,
ac.Account_First_Name + ' ' + ac.Account_Last_Name AS Account_Name,
ac.Account_Address ,
ac.Account_Type ,
ac.Account_PhoneNumber ,
aiur.RequestDescription 
FROM AccountInfoUpdateRequests aiur 
LEFT JOIN Accounts ac ON ac.Account_No = aiur.AccountNumber
WHERE Admin_Id =9004

--it doesnt works when i write liek this | zero rows
exec sp_executesql N'
SELECT 
aiur.AccountNumber,
ac.Account_First_Name + '' '' + ac.Account_Last_Name AS Account_Name,
ac.Account_Address,
ac.Account_Type,
ac.Account_PhoneNumber,
aiur.RequestDescription 
FROM AccountInfoUpdateRequests aiur 
LEFT JOIN Accounts ac ON ac.Account_No = aiur.AccountNumber
WHERE aiur.AccountNumber = @AccountNumber',N'@AccountNumber int',@AccountNumber= '9004'



SELECT 
Bill_Amount, 
ac.Account_No,
Payment_Date,
Bill_Type
from BillPayment bp
LEFT JOIN Accounts ac 
ON ac.Account_No = bp.Account_No
WHERE bp.IsPaid = 1 
AND Admin_Id = @AdminId

Select * from BillPayment



INSERT INTO Transaction_History (Receiver_Account_Id, Sender_Account_Id, Transaction_Type, Amount, Transaction_Date, Transaction_Status)
VALUES
    (10034, 10036, 'Deposit', 100.50, '2024-06-14 08:30:00', NULL),
    (10036, 10039, 'Deposit', 500.00, '2024-06-14 09:15:00', NULL),
    (NULL, 10036, 'Bill Payment', 75.25, '2024-06-14 10:00:00', 'Paid'),
    (10040, 10036, 'Deposit', 200.75, '2024-06-14 11:30:00', NULL);


select * from Transaction_History 

SELECT ADMIN_ID FROM accounts where account_no = 10040 --9001
SELECT ADMIN_ID FROM accounts where account_no = 10034 --9001
SELECT ADMIN_ID FROM accounts where account_no = 10036 --9004
SELECT ADMIN_ID FROM accounts where account_no = 10013 --9004
SELECT ADMIN_ID FROM accounts where account_no = 10039 --9006




INSERT INTO AccountInfoUpdateRequests VAlues(10013, 'update my address to Karsaz')


INSERT INTO BillPayment (Account_No, Bill_Type, Bill_Amount, Payment_Date) VALUES
(10013, 'Electricity', 1500.00, GETDATE()),
(10033, 'Water', 7500.00, GETDATE()),
(10034, 'Gas', 450.00, GETDATE()),
(10035, 'Internet', 600.00, GETDATE()),
(10036, 'Telephone', 300.00, GETDATE()),
(10037, 'Cable TV', 400.00, GETDATE()),
(10038, 'Electricity', 1600.00, GETDATE()),
(10039, 'Water', 8000.00, GETDATE()),
(10040, 'Gas', 500.00, GETDATE()),
(10041, 'Interne/t', 700.00, GETDATE());


SELECT * FROM Branch
SELECT * FROM Accounts
SELECT * FROM Admins
SELECT * FROM Transaction_History
SELECT * FROM BillPayment
SELECT * FROM Deposit
SELECT * FROM Balance
select * from AccountInfoUpdateRequests
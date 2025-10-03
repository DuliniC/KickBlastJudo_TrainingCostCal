--CREATE DATABASE KickBlastJudoDB;
GO
USE KickBlastJudoDB;


IF OBJECT_ID('dbo.TrainingPlans', 'U') IS NOT NULL
    DROP TABLE dbo.TrainingPlans;
GO

CREATE TABLE dbo.TrainingPlans (
    PlanID INT PRIMARY KEY IDENTITY(1,1),
    PlanName VARCHAR(20) UNIQUE NOT NULL,
    SessionsPerWeek INT NOT NULL,
    WeeklyFee DECIMAL(10,2) NOT NULL,
    CanEnterCompetitions BIT DEFAULT 0
);
GO

-- Beginner Plan
INSERT INTO dbo.TrainingPlans (PlanName, SessionsPerWeek, WeeklyFee, CanEnterCompetitions)
VALUES ('Beginner', 2, 250.00, 0);

-- Intermediate Plan
INSERT INTO dbo.TrainingPlans (PlanName, SessionsPerWeek, WeeklyFee, CanEnterCompetitions)
VALUES ('Intermediate', 3, 300.00, 1);

-- Elite Plan
INSERT INTO dbo.TrainingPlans (PlanName, SessionsPerWeek, WeeklyFee, CanEnterCompetitions)
VALUES ('Elite', 5, 350.00, 1);

IF OBJECT_ID('dbo.WeightCategories', 'U') IS NOT NULL
    DROP TABLE dbo.WeightCategories;
GO

CREATE TABLE dbo.WeightCategories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(30) UNIQUE NOT NULL,
    UpperWeightLimit DECIMAL(5,2),
    Description TEXT,
    DisplayOrder INT
);
GO

-- Heavyweight (Over 100, Unlimited)
INSERT INTO dbo.WeightCategories (CategoryName, UpperWeightLimit, Description,DisplayOrder)
VALUES ('Heavyweight', NULL, 'Over 100 kg (Unlimited)',6);   -- NULL means no upper limit

-- Light-Heavyweight
INSERT INTO dbo.WeightCategories (CategoryName, UpperWeightLimit, Description,DisplayOrder)
VALUES ('Light-Heavyweight', 100.00,'Up to 100 kg',5);

-- Middleweight
INSERT INTO dbo.WeightCategories (CategoryName, UpperWeightLimit, Description,DisplayOrder)
VALUES ('Middleweight', 90.00, 'Up to 90 kg',4);

-- Light-Middleweight
INSERT INTO dbo.WeightCategories (CategoryName, UpperWeightLimit, Description,DisplayOrder)
VALUES ('Light-Middleweight', 81.00,'Up to 80 kg',3);

-- Lightweight
INSERT INTO dbo.WeightCategories (CategoryName, UpperWeightLimit, Description,DisplayOrder)
VALUES ('Lightweight', 73.00,'Up to 73 kg',2);

-- Flyweight
INSERT INTO dbo.WeightCategories (CategoryName, UpperWeightLimit, Description,DisplayOrder)
VALUES ('Flyweight', 66.00,'Up to 66 kg',1);

----------
IF OBJECT_ID('dbo.Athletes', 'U') IS NOT NULL
    DROP TABLE dbo.Athletes;
GO

-- Create the Athletes table.
CREATE TABLE dbo.Athletes
(
    -- AthleteID is the primary key and will auto-increment.
    AthleteID INT IDENTITY(1,1) PRIMARY KEY,

    -- Name of the athlete, cannot be null.
    AthleteName NVARCHAR(100) NOT NULL,

    TrainingPlan int NOT NULL,

    -- Current weight, allowing for decimal values.
    CurrentWeightKg DECIMAL(5, 2) NOT NULL,

    -- Competition category as a string.
    CompetitionCategory INT NOT NULL,

    -- Number of competitions entered, with a default of 0.
    CompetitionEntered INT NOT NULL DEFAULT 0,

    -- Hours of private coaching, with a default of 0.
    PrivateCoachingHours INT NOT NULL DEFAULT 0,
    FOREIGN KEY (TrainingPlan) REFERENCES dbo.TrainingPlans(PlanID)
);
GO

-- You can optionally insert some sample data to test the table.
INSERT INTO dbo.Athletes (AthleteName, TrainingPlan, CurrentWeightKg, CompetitionCategory, CompetitionEntered, PrivateCoachingHours)
VALUES
    -- Athlete 1: An elite heavyweight competitor
    ('Ravi Perera', 1, 105.5, 6, 3, 4),

    -- Athlete 2: An intermediate middleweight competitor
    ('Anusha Silva', 2, 85.0, 4, 2, 2),

    -- Athlete 3: A beginner lightweight, not competing
    ('Saman Jayasinghe', 1, 72.1, 2, 0, 1),

    -- Athlete 4: An intermediate flyweight who competes often
    ('Fathima Rizwan', 2, 58.5, 1, 4, 3),

    -- Athlete 5: An elite light-middleweight with max private coaching
    ('Dinesh Kumar', 3, 80.0, 3, 5, 5),

    -- Athlete 6: A new beginner with no extra coaching
    ('Nimali Fernando', 1, 65.0, 2, 0, 0);
GO
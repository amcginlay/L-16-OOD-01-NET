IF OBJECT_ID('dbo.broker', 'U') IS NOT NULL DROP TABLE broker;
IF OBJECT_ID('dbo.company', 'U') IS NOT NULL DROP TABLE company;

CREATE TABLE company
(
      id INT PRIMARY KEY,
      name VARCHAR(255),
      city VARCHAR(255)
);

CREATE TABLE broker
(
      id INT PRIMARY KEY,
      name VARCHAR(255),
      fk_company_id INT FOREIGN KEY REFERENCES company(id),
      city VARCHAR(255)
      --,active INT
);

INSERT INTO company values (1, 'Microsoft', 'Redmond');
INSERT INTO broker values (1, 'Dan', 1, 'London'); -- , 1);

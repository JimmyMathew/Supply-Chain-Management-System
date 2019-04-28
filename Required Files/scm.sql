-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 24, 2019 at 11:56 AM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `scm`
--

-- --------------------------------------------------------

--
-- Table structure for table `deliveryunit`
--

CREATE TABLE `deliveryunit` (
  `id` bigint(20) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `distributorid` bigint(20) DEFAULT NULL,
  `distributorname` varchar(100) DEFAULT NULL,
  `productid` bigint(20) DEFAULT NULL,
  `productname` varchar(100) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `createdOn` date DEFAULT NULL,
  `isactive` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `deliveryunit`
--

INSERT INTO `deliveryunit` (`id`, `name`, `distributorid`, `distributorname`, `productid`, `productname`, `quantity`, `createdOn`, `isactive`) VALUES
(31, 'Customer2', 6, 'Distributor1', 28, 'Milk', 20, '2019-02-24', 0);

-- --------------------------------------------------------

--
-- Table structure for table `distributorunit`
--

CREATE TABLE `distributorunit` (
  `id` bigint(20) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `distributorId` bigint(20) DEFAULT NULL,
  `productname` varchar(100) DEFAULT NULL,
  `productid` bigint(20) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `createdOn` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `distributorunit`
--

INSERT INTO `distributorunit` (`id`, `name`, `distributorId`, `productname`, `productid`, `quantity`, `createdOn`) VALUES
(35, 'Distributor2', 8, 'Rice', 26, 10, '2019-02-24');

-- --------------------------------------------------------

--
-- Table structure for table `manufacturerunit`
--

CREATE TABLE `manufacturerunit` (
  `id` bigint(20) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `productname` varchar(500) DEFAULT NULL,
  `productid` bigint(20) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `createdOn` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `manufacturerunit`
--

INSERT INTO `manufacturerunit` (`id`, `name`, `productname`, `productid`, `quantity`, `createdOn`) VALUES
(15, 'Manufacturer1', 'Milk', 28, 80, '2019-02-24'),
(16, 'Manufacturer2', 'Rice', 26, 10, '2019-02-24');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `id` bigint(50) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `description` varchar(500) DEFAULT NULL,
  `model` varchar(100) DEFAULT NULL,
  `sku` varchar(100) DEFAULT NULL,
  `upc` varchar(100) DEFAULT NULL,
  `price` double DEFAULT NULL,
  `quantity` int(50) DEFAULT NULL,
  `createdBy` varchar(100) DEFAULT NULL,
  `createdOn` date DEFAULT NULL,
  `updatedBy` varchar(100) DEFAULT NULL,
  `updatedOn` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `name`, `description`, `model`, `sku`, `upc`, `price`, `quantity`, `createdBy`, `createdOn`, `updatedBy`, `updatedOn`) VALUES
(26, 'Rice', '', 'ricemodel', 'ricesku', 'riceupc', 100, 0, 'Admin', '2019-02-24', 'Admin', '2019-02-24'),
(28, 'Milk', 'milk description', 'milkmodel', 'milk sku', 'milk upc', 50, 0, 'Admin', '2019-02-24', 'Admin', '2019-02-24');

-- --------------------------------------------------------

--
-- Table structure for table `stakeholders`
--

CREATE TABLE `stakeholders` (
  `id` bigint(50) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `location` varchar(100) DEFAULT NULL,
  `type` varchar(100) DEFAULT NULL,
  `createdBy` varchar(100) DEFAULT NULL,
  `createOn` date DEFAULT NULL,
  `updateBy` varchar(100) DEFAULT NULL,
  `updateOn` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `stakeholders`
--

INSERT INTO `stakeholders` (`id`, `name`, `location`, `type`, `createdBy`, `createOn`, `updateBy`, `updateOn`) VALUES
(4, 'Manufacturer1', 'Chennai', 'Manufacturer', 'Admin', '2019-02-24', 'Admin', '2019-02-24'),
(5, 'Manufacturer2', 'Delhi', 'Manufacturer', 'Admin', '2019-02-24', 'Admin', '2019-02-24'),
(6, 'Distributor1', 'Kerala', 'Distributor', 'Admin', '2019-02-24', 'Admin', '2019-02-24'),
(8, 'Distributor2', 'Chennai', 'Distributor', 'Admin', '2019-02-24', 'Admin', '2019-02-24'),
(9, 'Customer1', 'Mumbai', 'Customer', 'Admin', '2019-02-24', 'Admin', '2019-02-24'),
(10, 'Customer2', 'Agra', 'Customer', 'Admin', '2019-02-24', 'Admin', '2019-02-24');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` bigint(50) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `username` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  `role` varchar(100) DEFAULT NULL,
  `createdBy` varchar(100) DEFAULT NULL,
  `createdOn` date DEFAULT NULL,
  `updatedBy` varchar(100) DEFAULT NULL,
  `updatedOn` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='To create users who access and use this application';

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `username`, `password`, `role`, `createdBy`, `createdOn`, `updatedBy`, `updatedOn`) VALUES
(6, 'Arun Swaminathan', 'gssarusu', 'arun', 'Admin', 'Admin', '2019-02-24', 'Admin', '2019-02-24'),
(7, 'admin', 'admin', 'admin', 'Admin', 'Admin', '2019-02-24', 'Admin', '2019-02-24'),
(8, 'Jimmy Mathew', 'jimmy', 'jimmy', 'Supervisor', 'Admin', '2019-02-24', 'Admin', '2019-02-24');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `deliveryunit`
--
ALTER TABLE `deliveryunit`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `distributorunit`
--
ALTER TABLE `distributorunit`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `manufacturerunit`
--
ALTER TABLE `manufacturerunit`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stakeholders`
--
ALTER TABLE `stakeholders`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `deliveryunit`
--
ALTER TABLE `deliveryunit`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `distributorunit`
--
ALTER TABLE `distributorunit`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `manufacturerunit`
--
ALTER TABLE `manufacturerunit`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` bigint(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT for table `stakeholders`
--
ALTER TABLE `stakeholders`
  MODIFY `id` bigint(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 14, 2022 at 12:36 AM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `crmsystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `project`
--

CREATE TABLE `project` (
  `id` int(11) NOT NULL,
  `users_id` int(11) DEFAULT NULL,
  `ProjectTitle` varchar(255) DEFAULT NULL,
  `ProjectDescription` varchar(255) DEFAULT NULL,
  `Projectdeadline` date DEFAULT NULL,
  `ProjectStatus` varchar(255) DEFAULT NULL
) ;

--
-- Dumping data for table `project`
--

INSERT INTO `project` (`id`, `users_id`, `ProjectTitle`, `ProjectDescription`, `Projectdeadline`, `ProjectStatus`) VALUES
(1, 1, 'Projekat1', 'Tralalal adaika hiad', '2023-12-23', 'Open'),
(2, 1, 'aaaaa', 'daadad', '2222-12-22', 'Cancelled'),
(3, 1, 'sfsfsf', 'fsffss', '2222-02-22', 'Open'),
(13, 4, 'aaa', 'fsfs', '2222-12-22', 'In Progress'),
(14, 8, 'Projekat 2', 'Tu ima nesto', '2222-12-22', 'In Progress'),
(16, 8, 'ewwe', 'eweww', '2222-12-22', 'Open'),
(17, 1, 'novi dodat', 'daadad', '2222-12-22', 'Cancelled'),
(18, 5, 'aaa', 'aaaa', '0022-12-22', 'In Progress');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `passwordHash` varchar(255) DEFAULT 'password',
  `role` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `email`, `passwordHash`, `role`) VALUES
(1, 'taki', 'rarr', 'password', 0),
(4, 'hufsffssfshu', 'isi@a', 'password', 1),
(5, 'Zuzi', 'isi@a', 'password', 1),
(8, 'MarijaAdmin', 'marija', 'marija', 1),
(10, 'MarijaAdmin', 'admin', 'admin', 0),
(12, 'Novi dodati', 'aaa', 'password', 1),
(13, 'Novi dodati', 'aaa', 'password', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `project`
--
ALTER TABLE `project`
  ADD PRIMARY KEY (`id`),
  ADD KEY `users_id` (`users_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `project`
--
ALTER TABLE `project`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `project`
--
ALTER TABLE `project`
  ADD CONSTRAINT `project_ibfk_1` FOREIGN KEY (`users_id`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

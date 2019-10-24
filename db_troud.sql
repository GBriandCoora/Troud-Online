-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Oct 24, 2019 at 04:42 PM
-- Server version: 5.7.11
-- PHP Version: 7.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_troud`
--

-- --------------------------------------------------------

--
-- Table structure for table `t_connected`
--

CREATE TABLE `t_connected` (
  `fk_player` tinyint(4) NOT NULL,
  `fk_game` tinyint(4) NOT NULL,
  `isReady` tinyint(1) NOT NULL DEFAULT '0',
  `lstCo` date NOT NULL,
  `nbr` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `t_forum`
--

CREATE TABLE `t_forum` (
  `id` tinyint(4) NOT NULL,
  `fk_player` tinyint(4) NOT NULL,
  `date` date NOT NULL,
  `message` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `t_game`
--

CREATE TABLE `t_game` (
  `id` tinyint(4) NOT NULL,
  `card` varchar(4) NOT NULL DEFAULT '0',
  `isRunning` tinyint(1) NOT NULL DEFAULT '0',
  `currentPlayer` tinyint(4) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `t_player`
--

CREATE TABLE `t_player` (
  `id` tinyint(4) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(25) NOT NULL,
  `nbrGame` smallint(5) NOT NULL DEFAULT '0',
  `nbrWin` smallint(5) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `t_player`
--

INSERT INTO `t_player` (`id`, `username`, `password`, `nbrGame`, `nbrWin`) VALUES
(1, 'Greg', 'Imacutekayx', 0, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `t_forum`
--
ALTER TABLE `t_forum`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `t_game`
--
ALTER TABLE `t_game`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `t_player`
--
ALTER TABLE `t_player`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `t_forum`
--
ALTER TABLE `t_forum`
  MODIFY `id` tinyint(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `t_game`
--
ALTER TABLE `t_game`
  MODIFY `id` tinyint(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `t_player`
--
ALTER TABLE `t_player`
  MODIFY `id` tinyint(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

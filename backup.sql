-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- ����: 127.0.0.1:3306
-- ����� ��������: ��� 14 2023 �., 10:02
-- ������ �������: 10.3.22-MariaDB
-- ������ PHP: 7.1.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- ���� ������: `russian_cosmetic`
--

-- --------------------------------------------------------

--
-- ��������� ������� `clients`
--

CREATE TABLE `clients` (
  `client_id` int(11) NOT NULL COMMENT 'ID �������',
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'E-mail',
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '��� ������',
  `is_ur` tinyint(1) NOT NULL COMMENT '�������� �� ������ ����������� �����',
  `removed` tinyint(1) NOT NULL DEFAULT 0 COMMENT '����� �� ������'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='������� ��������';

--
-- ���� ������ ������� `clients`
--

INSERT INTO `clients` (`client_id`, `email`, `password`, `is_ur`, `removed`) VALUES
(10, '1', 'EC278A38901287B2771A13739520384D43E4B078F78AFFE702DEF108774CCE24', 0, 0),
(11, 'petr@gmail.com', '716C090160D67F72C6F6562BC6D2723EE79B1ACC03DC7C72C604C0DEBBA63B4D', 0, 0),
(12, 'semenovich@gmail.com', '716C090160D67F72C6F6562BC6D2723EE79B1ACC03DC7C72C604C0DEBBA63B4D', 0, 0),
(14, '12', 'EC278A38901287B2771A13739520384D43E4B078F78AFFE702DEF108774CCE24', 0, 0);

-- --------------------------------------------------------

--
-- ��������� ������� `clients_phys`
--

CREATE TABLE `clients_phys` (
  `client_id` int(11) NOT NULL COMMENT 'ID �������',
  `name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '���',
  `surname` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '�������',
  `patronymic` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '��������',
  `birthday` date NOT NULL COMMENT '���� ��������',
  `passport` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '����� � ����� ��������',
  `phone` varchar(12) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '����� ��������'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='������� �������� - ���������� ���';

--
-- ���� ������ ������� `clients_phys`
--

INSERT INTO `clients_phys` (`client_id`, `name`, `surname`, `patronymic`, `birthday`, `passport`, `phone`) VALUES
(10, '����', '������', '��������', '2023-12-13', '0111111111', '70222222222'),
(11, 'ϸ��', '������', '��������', '2023-12-13', '0333333333', '74444444444'),
(12, '����', '������', '��������', '2023-12-13', '5555555555', '76666666666'),
(14, '1', '1', '1', '2023-12-13', '0111111111', '70111111111');

-- --------------------------------------------------------

--
-- ��������� ������� `clients_ur`
--

CREATE TABLE `clients_ur` (
  `client_id` int(11) NOT NULL COMMENT 'ID �������',
  `title` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '�������� ��������',
  `address` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '�����',
  `INN` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '���',
  `rs` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '��������� ����',
  `BIK` varchar(11) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '���',
  `name_head` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '��� ������������',
  `surname_head` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '������� ������������',
  `patronymic_head` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '�������� ������������',
  `name_contact` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '��� ����������� ����',
  `surname_contact` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '������� ����������� ����',
  `patronymic_contact` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '�������� ����������� ����',
  `phone_contact` varchar(12) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '������� ����������� ����'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='������� �������� - ����������� ���';

-- --------------------------------------------------------

--
-- ��������� ������� `orders`
--

CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL COMMENT 'ID ������',
  `data_create` timestamp NOT NULL DEFAULT current_timestamp() COMMENT '���� � ����� ��������',
  `status` int(11) NOT NULL DEFAULT 1 COMMENT 'ID ������� ������',
  `duration` float NOT NULL DEFAULT 0 COMMENT '������������, �',
  `client` int(11) NOT NULL COMMENT 'ID �������',
  `removed` tinyint(1) NOT NULL DEFAULT 0 COMMENT '�������'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='������� �������';

-- --------------------------------------------------------

--
-- ��������� ������� `orders_servieces`
--

CREATE TABLE `orders_servieces` (
  `order_id` int(11) NOT NULL COMMENT 'ID ������',
  `service_id` int(11) NOT NULL COMMENT 'ID ������',
  `status` int(11) NOT NULL COMMENT 'ID �������',
  `datetime_comlplete` timestamp NULL DEFAULT NULL COMMENT '���� � ����� ����������',
  `employee` int(11) DEFAULT NULL COMMENT 'ID ����������'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='����� ����� ������� � �������� "������-��-������"';

-- --------------------------------------------------------

--
-- ��������� ������� `services`
--

CREATE TABLE `services` (
  `service_id` int(11) NOT NULL COMMENT 'ID ������',
  `service_title` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '������������ ������',
  `price` decimal(11,2) NOT NULL COMMENT '����, ���',
  `duration` float NOT NULL COMMENT '������������, �',
  `std` double NOT NULL DEFAULT 0 COMMENT '����������� ����������'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- ���� ������ ������� `services`
--

INSERT INTO `services` (`service_id`, `service_title`, `price`, `duration`, `std`) VALUES
(3, '���������� ���������� pH', '500.00', 0.25, 0.5),
(4, '��������� �����', '1500.00', 1.5, 0.01),
(5, '���������� ������', '3000.00', 1.25, 0.01),
(6, '��������� ����', '3500.00', 6, 0.01),
(7, '���������� ������ ������', '2500.00', 2, 0.01);

-- --------------------------------------------------------

--
-- ��������� ������� `statuses`
--

CREATE TABLE `statuses` (
  `status_id` int(11) NOT NULL COMMENT 'ID �������',
  `status_title` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '������'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='������� ��������';

--
-- ���� ������ ������� `statuses`
--

INSERT INTO `statuses` (`status_id`, `status_title`) VALUES
(2, '� ��������'),
(4, '��������'),
(3, '����� � ������'),
(5, '������'),
(1, '������');

--
-- ������� ���������� ������
--

--
-- ������� ������� `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`client_id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- ������� ������� `clients_phys`
--
ALTER TABLE `clients_phys`
  ADD PRIMARY KEY (`client_id`);

--
-- ������� ������� `clients_ur`
--
ALTER TABLE `clients_ur`
  ADD PRIMARY KEY (`client_id`);

--
-- ������� ������� `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `status` (`status`),
  ADD KEY `client` (`client`);

--
-- ������� ������� `orders_servieces`
--
ALTER TABLE `orders_servieces`
  ADD PRIMARY KEY (`order_id`,`service_id`);

--
-- ������� ������� `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`service_id`),
  ADD UNIQUE KEY `service_title` (`service_title`);

--
-- ������� ������� `statuses`
--
ALTER TABLE `statuses`
  ADD PRIMARY KEY (`status_id`),
  ADD UNIQUE KEY `status_title` (`status_title`);

--
-- AUTO_INCREMENT ��� ���������� ������
--

--
-- AUTO_INCREMENT ��� ������� `clients`
--
ALTER TABLE `clients`
  MODIFY `client_id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID �������', AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT ��� ������� `orders`
--
ALTER TABLE `orders`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID ������', AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT ��� ������� `services`
--
ALTER TABLE `services`
  MODIFY `service_id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID ������', AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT ��� ������� `statuses`
--
ALTER TABLE `statuses`
  MODIFY `status_id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID �������', AUTO_INCREMENT=6;

--
-- ����������� �������� ����� ����������� ������
--

--
-- ����������� �������� ����� ������� `clients_phys`
--
ALTER TABLE `clients_phys`
  ADD CONSTRAINT `clients_phys_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clients` (`client_id`);

--
-- ����������� �������� ����� ������� `clients_ur`
--
ALTER TABLE `clients_ur`
  ADD CONSTRAINT `clients_ur_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clients` (`client_id`);

--
-- ����������� �������� ����� ������� `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`status`) REFERENCES `statuses` (`status_id`),
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`client`) REFERENCES `clients` (`client_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

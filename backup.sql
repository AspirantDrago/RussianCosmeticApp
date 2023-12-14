-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Дек 14 2023 г., 10:02
-- Версия сервера: 10.3.22-MariaDB
-- Версия PHP: 7.1.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `russian_cosmetic`
--

-- --------------------------------------------------------

--
-- Структура таблицы `clients`
--

CREATE TABLE `clients` (
  `client_id` int(11) NOT NULL COMMENT 'ID клиента',
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'E-mail',
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Хэш пароля',
  `is_ur` tinyint(1) NOT NULL COMMENT 'Является ли клиент юридическим лицом',
  `removed` tinyint(1) NOT NULL DEFAULT 0 COMMENT 'Удалён ли клиент'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Таблица клиентов';

--
-- Дамп данных таблицы `clients`
--

INSERT INTO `clients` (`client_id`, `email`, `password`, `is_ur`, `removed`) VALUES
(10, '1', 'EC278A38901287B2771A13739520384D43E4B078F78AFFE702DEF108774CCE24', 0, 0),
(11, 'petr@gmail.com', '716C090160D67F72C6F6562BC6D2723EE79B1ACC03DC7C72C604C0DEBBA63B4D', 0, 0),
(12, 'semenovich@gmail.com', '716C090160D67F72C6F6562BC6D2723EE79B1ACC03DC7C72C604C0DEBBA63B4D', 0, 0),
(14, '12', 'EC278A38901287B2771A13739520384D43E4B078F78AFFE702DEF108774CCE24', 0, 0);

-- --------------------------------------------------------

--
-- Структура таблицы `clients_phys`
--

CREATE TABLE `clients_phys` (
  `client_id` int(11) NOT NULL COMMENT 'ID клиента',
  `name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Имя',
  `surname` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Фамилия',
  `patronymic` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Отчество',
  `birthday` date NOT NULL COMMENT 'Дата рождения',
  `passport` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Серия и номер паспорта',
  `phone` varchar(12) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Номер телефона'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Таблица клиентов - физических лиц';

--
-- Дамп данных таблицы `clients_phys`
--

INSERT INTO `clients_phys` (`client_id`, `name`, `surname`, `patronymic`, `birthday`, `passport`, `phone`) VALUES
(10, 'Иван', 'Иванов', 'Иванович', '2023-12-13', '0111111111', '70222222222'),
(11, 'Пётр', 'Петров', 'Петрович', '2023-12-13', '0333333333', '74444444444'),
(12, 'Семён', 'Семёнов', 'Семёнович', '2023-12-13', '5555555555', '76666666666'),
(14, '1', '1', '1', '2023-12-13', '0111111111', '70111111111');

-- --------------------------------------------------------

--
-- Структура таблицы `clients_ur`
--

CREATE TABLE `clients_ur` (
  `client_id` int(11) NOT NULL COMMENT 'ID клиента',
  `title` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Название компании',
  `address` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Адрес',
  `INN` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'ИНН',
  `rs` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Расчётный счёт',
  `BIK` varchar(11) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'БИК',
  `name_head` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Имя руководителя',
  `surname_head` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Фамилия руководителя',
  `patronymic_head` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Отчество руководителя',
  `name_contact` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Имя контактного лица',
  `surname_contact` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Фамилия контактного лица',
  `patronymic_contact` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Отчество контактного лица',
  `phone_contact` varchar(12) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Телефон контактного лица'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Таблица клиентов - юридических лиц';

-- --------------------------------------------------------

--
-- Структура таблицы `orders`
--

CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL COMMENT 'ID заказа',
  `data_create` timestamp NOT NULL DEFAULT current_timestamp() COMMENT 'Дата и время создания',
  `status` int(11) NOT NULL DEFAULT 1 COMMENT 'ID статуса заказа',
  `duration` float NOT NULL DEFAULT 0 COMMENT 'Длительность, ч',
  `client` int(11) NOT NULL COMMENT 'ID клиента',
  `removed` tinyint(1) NOT NULL DEFAULT 0 COMMENT 'Удалено'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Таблица заказов';

-- --------------------------------------------------------

--
-- Структура таблицы `orders_servieces`
--

CREATE TABLE `orders_servieces` (
  `order_id` int(11) NOT NULL COMMENT 'ID заказа',
  `service_id` int(11) NOT NULL COMMENT 'ID услуги',
  `status` int(11) NOT NULL COMMENT 'ID статуса',
  `datetime_comlplete` timestamp NULL DEFAULT NULL COMMENT 'Дата и время завершения',
  `employee` int(11) DEFAULT NULL COMMENT 'ID сотрудника'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Связь между заказом и услугами "многие-ко-многим"';

-- --------------------------------------------------------

--
-- Структура таблицы `services`
--

CREATE TABLE `services` (
  `service_id` int(11) NOT NULL COMMENT 'ID услуги',
  `service_title` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Наименование услуги',
  `price` decimal(11,2) NOT NULL COMMENT 'Цена, руб',
  `duration` float NOT NULL COMMENT 'Длительность, ч',
  `std` double NOT NULL DEFAULT 0 COMMENT 'Стандартное отклонение'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `services`
--

INSERT INTO `services` (`service_id`, `service_title`, `price`, `duration`, `std`) VALUES
(3, 'Водородный показатель pH', '500.00', 0.25, 0.5),
(4, 'Кислотное число', '1500.00', 1.5, 0.01),
(5, 'Содержание фенола', '3000.00', 1.25, 0.01),
(6, 'Стойкость пены', '3500.00', 6, 0.01),
(7, 'Содержание жирных кислот', '2500.00', 2, 0.01);

-- --------------------------------------------------------

--
-- Структура таблицы `statuses`
--

CREATE TABLE `statuses` (
  `status_id` int(11) NOT NULL COMMENT 'ID статуса',
  `status_title` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL COMMENT 'Статус'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci COMMENT='Таблица статусов';

--
-- Дамп данных таблицы `statuses`
--

INSERT INTO `statuses` (`status_id`, `status_title`) VALUES
(2, 'В процессе'),
(4, 'Выполнен'),
(3, 'Готов к выдаче'),
(5, 'Отменён'),
(1, 'Создан');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`client_id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Индексы таблицы `clients_phys`
--
ALTER TABLE `clients_phys`
  ADD PRIMARY KEY (`client_id`);

--
-- Индексы таблицы `clients_ur`
--
ALTER TABLE `clients_ur`
  ADD PRIMARY KEY (`client_id`);

--
-- Индексы таблицы `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `status` (`status`),
  ADD KEY `client` (`client`);

--
-- Индексы таблицы `orders_servieces`
--
ALTER TABLE `orders_servieces`
  ADD PRIMARY KEY (`order_id`,`service_id`);

--
-- Индексы таблицы `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`service_id`),
  ADD UNIQUE KEY `service_title` (`service_title`);

--
-- Индексы таблицы `statuses`
--
ALTER TABLE `statuses`
  ADD PRIMARY KEY (`status_id`),
  ADD UNIQUE KEY `status_title` (`status_title`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `clients`
--
ALTER TABLE `clients`
  MODIFY `client_id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID клиента', AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT для таблицы `orders`
--
ALTER TABLE `orders`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID заказа', AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `services`
--
ALTER TABLE `services`
  MODIFY `service_id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID услуги', AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `statuses`
--
ALTER TABLE `statuses`
  MODIFY `status_id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID статуса', AUTO_INCREMENT=6;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `clients_phys`
--
ALTER TABLE `clients_phys`
  ADD CONSTRAINT `clients_phys_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clients` (`client_id`);

--
-- Ограничения внешнего ключа таблицы `clients_ur`
--
ALTER TABLE `clients_ur`
  ADD CONSTRAINT `clients_ur_ibfk_1` FOREIGN KEY (`client_id`) REFERENCES `clients` (`client_id`);

--
-- Ограничения внешнего ключа таблицы `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`status`) REFERENCES `statuses` (`status_id`),
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`client`) REFERENCES `clients` (`client_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

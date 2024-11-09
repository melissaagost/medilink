-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost:3307
-- Tiempo de generación: 09-11-2024 a las 23:17:57
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `medilink`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cita`
--

CREATE TABLE `cita` (
  `id_cita` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `motivo` varchar(300) NOT NULL,
  `status` varchar(100) NOT NULL DEFAULT 'activa',
  `id_paciente` int(11) NOT NULL,
  `id_medico` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `cita`
--

INSERT INTO `cita` (`id_cita`, `fecha`, `motivo`, `status`, `id_paciente`, `id_medico`) VALUES
(1, '2024-12-01', 'Consulta general', 'activa', 1, 32),
(2, '2024-11-02', 'Chequeo anual', 'completada', 2, 32),
(3, '2024-11-30', 'Dolor abdominal', 'activa', 3, 32),
(4, '2024-11-04', 'Revisión de presión', 'activa', 4, 32),
(5, '2024-11-05', 'Consulta de seguimiento', 'completada', 5, 32),
(6, '2024-11-06', 'Examen de laboratorio', 'activa', 6, 32),
(7, '2024-11-07', 'Control de diabetes', 'cancelada', 7, 32),
(8, '2024-11-08', 'Evaluación de cirugía', 'completada', 8, 32),
(9, '2024-11-09', 'Dolor de cabeza persistente', 'activa', 9, 32),
(10, '2024-11-10', 'Chequeo de colesterol', 'completada', 10, 32),
(11, '2024-11-11', 'Revisión de rutina', 'activa', 11, 32),
(12, '2024-11-12', 'Consulta por fiebre', 'cancelada', 12, 32),
(13, '2024-11-13', 'Chequeo postoperatorio', 'completada', 13, 32),
(14, '2024-11-14', 'Dolor en la espalda', 'activa', 14, 32),
(15, '2024-11-15', 'Revisión de articulaciones', 'completada', 15, 32),
(16, '2024-11-16', 'Consulta general', 'activa', 1, 33),
(17, '2024-11-17', 'Chequeo anual', 'completada', 2, 33),
(18, '2024-11-18', 'Dolor abdominal', 'cancelada', 3, 33),
(19, '2024-11-19', 'Revisión de presión', 'activa', 4, 33),
(20, '2024-11-20', 'Consulta de seguimiento', 'completada', 5, 33),
(21, '2024-11-21', 'Examen de laboratorio', 'activa', 6, 33),
(22, '2024-11-22', 'Control de diabetes', 'cancelada', 7, 33),
(23, '2024-11-23', 'Evaluación de cirugía', 'completada', 8, 33),
(24, '2024-11-24', 'Dolor de cabeza persistente', 'activa', 9, 33),
(25, '2024-11-25', 'Chequeo de colesterol', 'completada', 10, 33),
(26, '2024-11-26', 'Revisión de rutina', 'activa', 11, 33),
(27, '2024-11-27', 'Consulta por fiebre', 'cancelada', 12, 33),
(28, '2024-11-28', 'Chequeo postoperatorio', 'completada', 13, 33),
(29, '2024-11-29', 'Dolor en la espalda', 'activa', 14, 33),
(30, '2024-11-30', 'Revisión de articulaciones', 'completada', 15, 33),
(31, '2024-12-01', 'Consulta general', 'activa', 1, 34),
(32, '2024-12-02', 'Chequeo anual', 'completada', 2, 34),
(33, '2024-12-03', 'Dolor abdominal', 'cancelada', 3, 34),
(34, '2024-12-04', 'Revisión de presión', 'activa', 4, 34),
(35, '2024-12-05', 'Consulta de seguimiento', 'completada', 5, 34),
(36, '2024-12-06', 'Examen de laboratorio', 'activa', 6, 34),
(37, '2024-12-07', 'Control de diabetes', 'cancelada', 7, 34),
(38, '2024-12-08', 'Evaluación de cirugía', 'completada', 8, 34),
(39, '2024-12-09', 'Dolor de cabeza persistente', 'activa', 9, 34),
(40, '2024-12-10', 'Chequeo de colesterol', 'completada', 10, 34),
(41, '2024-12-11', 'Revisión de rutina', 'activa', 11, 34),
(42, '2024-12-12', 'Consulta por fiebre', 'cancelada', 12, 34),
(43, '2024-12-13', 'Chequeo postoperatorio', 'completada', 13, 34),
(44, '2024-12-14', 'Dolor en la espalda', 'activa', 14, 34),
(45, '2024-12-15', 'Revisión de articulaciones', 'completada', 15, 34),
(46, '2024-12-16', 'Consulta general', 'activa', 1, 35),
(47, '2024-12-17', 'Chequeo anual', 'completada', 2, 35),
(48, '2024-12-18', 'Dolor abdominal', 'cancelada', 3, 35),
(49, '2024-12-19', 'Revisión de presión', 'activa', 4, 35),
(50, '2024-12-20', 'Consulta de seguimiento', 'completada', 5, 35),
(51, '2024-12-21', 'Examen de laboratorio', 'activa', 6, 35),
(52, '2024-12-22', 'Control de diabetes', 'cancelada', 7, 35),
(53, '2024-12-23', 'Evaluación de cirugía', 'completada', 8, 35),
(54, '2024-12-24', 'Dolor de cabeza persistente', 'activa', 9, 35),
(55, '2024-12-25', 'Chequeo de colesterol', 'completada', 10, 35),
(56, '2024-12-26', 'Revisión de rutina', 'activa', 11, 35),
(57, '2024-12-27', 'Consulta por fiebre', 'cancelada', 12, 35),
(58, '2024-12-28', 'Chequeo postoperatorio', 'completada', 13, 35),
(59, '2024-12-29', 'Dolor en la espalda', 'activa', 14, 35),
(60, '2024-12-30', 'Revisión de articulaciones', 'completada', 15, 35),
(61, '2024-12-16', 'Consulta general', 'activa', 1, 37),
(62, '2024-12-17', 'Chequeo anual', 'completada', 2, 37),
(63, '2024-12-18', 'Dolor abdominal', 'cancelada', 3, 37),
(64, '2024-12-19', 'Revisión de presión', 'activa', 4, 37),
(65, '2024-12-20', 'Consulta de seguimiento', 'completada', 5, 37),
(66, '2024-12-21', 'Examen de laboratorio', 'activa', 6, 37),
(67, '2024-12-22', 'Control de diabetes', 'cancelada', 7, 37),
(68, '2024-12-23', 'Evaluación de cirugía', 'completada', 8, 37),
(69, '2024-12-24', 'Dolor de cabeza persistente', 'activa', 9, 37),
(70, '2024-12-25', 'Chequeo de colesterol', 'completada', 10, 37),
(71, '2024-12-26', 'Revisión de rutina', 'activa', 11, 37),
(72, '2024-12-27', 'Consulta por fiebre', 'cancelada', 12, 37),
(73, '2024-12-28', 'Chequeo postoperatorio', 'completada', 13, 37),
(74, '2024-12-29', 'Dolor en la espalda', 'activa', 14, 37),
(75, '2024-12-30', 'Revisión de articulaciones', 'completada', 15, 37),
(76, '2024-12-16', 'Consulta general', 'activa', 1, 38),
(77, '2024-12-17', 'Chequeo anual', 'completada', 2, 38),
(78, '2024-12-18', 'Dolor abdominal', 'cancelada', 3, 38),
(79, '2024-12-19', 'Revisión de presión', 'activa', 4, 38),
(80, '2024-12-20', 'Consulta de seguimiento', 'completada', 5, 38),
(81, '2024-12-21', 'Examen de laboratorio', 'activa', 6, 38),
(82, '2024-12-22', 'Control de diabetes', 'cancelada', 7, 38),
(83, '2024-12-23', 'Evaluación de cirugía', 'completada', 8, 38),
(84, '2024-12-24', 'Dolor de cabeza persistente', 'activa', 9, 38),
(85, '2024-12-25', 'Chequeo de colesterol', 'completada', 10, 38),
(86, '2024-12-26', 'Revisión de rutina', 'activa', 11, 38),
(87, '2024-12-27', 'Consulta por fiebre', 'cancelada', 12, 38),
(88, '2024-12-28', 'Chequeo postoperatorio', 'completada', 13, 38),
(89, '2024-12-29', 'Dolor en la espalda', 'activa', 14, 38),
(90, '2024-12-30', 'Revisión de articulaciones', 'completada', 15, 38),
(91, '2024-12-16', 'Consulta general', 'activa', 1, 39),
(92, '2024-12-17', 'Chequeo anual', 'completada', 2, 39),
(93, '2024-12-18', 'Dolor abdominal', 'cancelada', 3, 39),
(94, '2024-12-19', 'Revisión de presión', 'activa', 4, 39),
(95, '2024-12-20', 'Consulta de seguimiento', 'completada', 5, 39),
(96, '2024-12-21', 'Examen de laboratorio', 'activa', 6, 39),
(97, '2024-12-22', 'Control de diabetes', 'cancelada', 7, 39),
(98, '2024-12-23', 'Evaluación de cirugía', 'completada', 8, 39),
(99, '2024-12-24', 'Dolor de cabeza persistente', 'activa', 9, 39),
(100, '2024-12-25', 'Chequeo de colesterol', 'completada', 10, 39),
(101, '2024-12-26', 'Revisión de rutina', 'activa', 11, 39),
(102, '2024-12-27', 'Consulta por fiebre', 'cancelada', 12, 39),
(103, '2024-12-28', 'Chequeo postoperatorio', 'completada', 13, 39),
(104, '2024-12-29', 'Dolor en la espalda', 'activa', 14, 39),
(105, '2024-12-30', 'Revisión de articulaciones', 'completada', 15, 39),
(106, '2024-12-16', 'Consulta general', 'activa', 1, 40),
(107, '2024-12-17', 'Chequeo anual', 'completada', 2, 40),
(108, '2024-12-18', 'Dolor abdominal', 'cancelada', 3, 40),
(109, '2024-12-19', 'Revisión de presión', 'activa', 4, 40),
(110, '2024-12-20', 'Consulta de seguimiento', 'completada', 5, 40),
(111, '2024-12-21', 'Examen de laboratorio', 'activa', 6, 40),
(112, '2024-12-22', 'Control de diabetes', 'cancelada', 7, 40),
(113, '2024-12-23', 'Evaluación de cirugía', 'completada', 8, 40),
(114, '2024-12-24', 'Dolor de cabeza persistente', 'activa', 9, 40),
(115, '2024-12-25', 'Chequeo de colesterol', 'completada', 10, 40),
(116, '2024-12-26', 'Revisión de rutina', 'activa', 11, 40),
(117, '2024-12-27', 'Consulta por fiebre', 'cancelada', 12, 40),
(118, '2024-12-28', 'Chequeo postoperatorio', 'completada', 13, 40),
(119, '2024-12-29', 'Dolor en la espalda', 'activa', 14, 40),
(120, '2024-12-30', 'Revisión de articulaciones', 'completada', 15, 40),
(121, '2024-12-07', 'test final', 'cancelada', 1, 35);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ciudad`
--

CREATE TABLE `ciudad` (
  `id_ciudad` int(11) NOT NULL,
  `nombre` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `ciudad`
--

INSERT INTO `ciudad` (`id_ciudad`, `nombre`) VALUES
(1, 'Buenos Aires'),
(2, 'La Plata'),
(3, 'San Fernando del Valle de Catamarca'),
(4, 'Resistencia'),
(5, 'Rawson'),
(6, 'Córdoba'),
(7, 'Corrientes'),
(8, 'Paraná'),
(9, 'Formosa'),
(10, 'San Salvador de Jujuy'),
(11, 'Santa Rosa'),
(12, 'La Rioja'),
(13, 'Mendoza'),
(14, 'Posadas'),
(15, 'Neuquén'),
(16, 'Viedma'),
(17, 'Salta'),
(18, 'San Juan'),
(19, 'San Luis'),
(20, 'Río Gallegos'),
(21, 'Santa Fe'),
(22, 'Santiago del Estero'),
(23, 'Ushuaia'),
(24, 'San Miguel de Tucumán');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `especialidad`
--

CREATE TABLE `especialidad` (
  `id_especialidad` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `especialidad`
--

INSERT INTO `especialidad` (`id_especialidad`, `nombre`) VALUES
(1, 'Nutricionista'),
(2, 'Ortodoncista'),
(3, 'Cirujano Plastico Facial'),
(4, 'Cirujano Plastico Corporal'),
(5, 'Dermatologo'),
(6, 'Cosmetologo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `medico`
--

CREATE TABLE `medico` (
  `id_medico` int(11) NOT NULL,
  `id_especialidad` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `id_turno` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `medico`
--

INSERT INTO `medico` (`id_medico`, `id_especialidad`, `id_usuario`, `id_turno`) VALUES
(32, 1, 136, 1),
(33, 2, 138, 2),
(34, 3, 140, 3),
(35, 4, 141, 1),
(37, 2, 139, 2),
(38, 3, 143, 3),
(39, 4, 155, 1),
(40, 5, 156, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `obra_social`
--

CREATE TABLE `obra_social` (
  `id_obra_social` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `obra_social`
--

INSERT INTO `obra_social` (`id_obra_social`, `nombre`) VALUES
(1, 'Pami'),
(2, 'Ioscor'),
(3, 'Osde'),
(4, 'Swiss Medical'),
(5, 'Issune'),
(6, 'Ninguna');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `paciente`
--

CREATE TABLE `paciente` (
  `id_paciente` int(11) NOT NULL,
  `dni` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `genero` varchar(2) NOT NULL,
  `status` varchar(100) NOT NULL DEFAULT 'si',
  `fecha_nacimiento` date NOT NULL,
  `correo` varchar(100) NOT NULL,
  `telefono` varchar(15) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `edad` int(11) NOT NULL,
  `id_obra_social` int(11) NOT NULL,
  `id_ciudad` int(11) NOT NULL,
  `id_provincia` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `paciente`
--

INSERT INTO `paciente` (`id_paciente`, `dni`, `nombre`, `apellido`, `genero`, `status`, `fecha_nacimiento`, `correo`, `telefono`, `direccion`, `edad`, `id_obra_social`, `id_ciudad`, `id_provincia`) VALUES
(1, 10101010, 'Juan', 'Pérez', 'M', 'si', '1985-05-15', 'juan.perez@example.com', '1234567890', 'Calle Uno', 39, 1, 3, 4),
(2, 20202020, 'María', 'Gómez', 'F', 'si', '1990-08-22', 'maria.gomez@example.com', '2345678901', 'Calle Dos', 34, 2, 5, 6),
(3, 30303030, 'Carlos', 'López', 'M', 'si', '1978-02-10', 'carlos.lopez@example.com', '3456789012', 'Calle Tres', 46, 3, 7, 2),
(4, 40404040, 'Ana', 'Martínez', 'F', 'si', '1995-07-30', 'ana.martinez@example.com', '4567890123', 'Calle Cuatro', 29, 4, 1, 8),
(5, 50505050, 'Luis', 'Torres', 'M', 'si', '1980-01-17', 'luis.torres@example.com', '5678901234', 'Calle Cinco', 44, 5, 9, 10),
(6, 60606060, 'Laura', 'Vega', 'F', 'si', '1987-03-05', 'laura.vega@example.com', '6789012345', 'Calle Seis', 37, 1, 4, 11),
(7, 70707070, 'Ricardo', 'Díaz', 'M', 'si', '1992-12-12', 'ricardo.diaz@example.com', '7890123456', 'Calle Siete', 31, 2, 5, 3),
(8, 80808080, 'Claudia', 'Sánchez', 'F', 'si', '1975-09-25', 'claudia.sanchez@example.com', '8901234567', 'Calle Ocho', 49, 3, 12, 14),
(9, 90909090, 'Miguel', 'Morales', 'M', 'si', '1998-04-04', 'miguel.morales@example.com', '9012345678', 'Calle Nueve', 26, 4, 13, 5),
(10, 11111111, 'Sofía', 'Fernández', 'F', 'si', '1983-06-20', 'sofia.fernandez@example.com', '0123456789', 'Calle Diez', 41, 5, 8, 1),
(11, 12121212, 'Esteban', 'Castro', 'M', 'si', '1991-11-15', 'esteban.castro@example.com', '1234567891', 'Calle Once', 32, 1, 15, 9),
(12, 13131313, 'Paula', 'Ramos', 'F', 'si', '1989-05-28', 'paula.ramos@example.com', '2345678912', 'Calle Doce', 35, 2, 3, 7),
(13, 14141414, 'Andrés', 'Molina', 'M', 'si', '1976-08-08', 'andres.molina@example.com', '3456789123', 'Calle Trece', 48, 3, 10, 12),
(14, 15151515, 'Elena', 'Ruiz', 'F', 'si', '1993-10-01', 'elena.ruiz@example.com', '4567891234', 'Calle Catorce', 31, 4, 6, 4),
(15, 16161616, 'Felipe', 'Pérez', 'M', 'si', '1981-01-03', 'felipe.perez@example.com', '5678912345', 'Calle Quince', 43, 5, 2, 11),
(16, 17171717, 'Verónica', 'Jiménez', 'F', 'si', '1996-09-14', 'veronica.jimenez@example.com', '6789123456', 'Calle Dieciseiss', 28, 1, 4, 15),
(17, 18181818, 'Hugo', 'Rojas', 'M', 'si', '1979-02-27', 'hugo.rojas@example.com', '7891234567', 'Calle Diecisiete', 45, 2, 11, 6),
(18, 19191919, 'Julia', 'Ortega', 'F', 'si', '1982-03-18', 'julia.ortega@example.com', '8901234568', 'Calle Dieciocho', 42, 3, 1, 13),
(19, 20202021, 'Sebastián', 'Iglesias', 'M', 'si', '1988-12-24', 'sebastian.iglesias@example.com', '9012345679', 'Calle Diecinueve', 35, 4, 9, 3),
(20, 21212121, 'Patricia', 'Núñez', 'F', 'si', '1994-11-11', 'patricia.nunez@example.com', '0123456790', 'Calle Veinte', 30, 5, 14, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `perfil`
--

CREATE TABLE `perfil` (
  `id_perfil` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `perfil`
--

INSERT INTO `perfil` (`id_perfil`, `nombre`) VALUES
(1, 'Sistemas'),
(2, 'Gestor'),
(3, 'Medico'),
(4, 'Recepcionista');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `provincia`
--

CREATE TABLE `provincia` (
  `id_provincia` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `provincia`
--

INSERT INTO `provincia` (`id_provincia`, `nombre`) VALUES
(1, 'Buenos Aires'),
(2, 'Catamarca'),
(3, 'Chaco'),
(4, 'Chubut'),
(5, 'Córdoba'),
(6, 'Corrientes'),
(7, 'Entre Ríos'),
(8, 'Formosa'),
(9, 'Jujuy'),
(10, 'La Pampa'),
(11, 'La Rioja'),
(12, 'Mendoza'),
(13, 'Misiones'),
(14, 'Neuquén'),
(15, 'Río Negro'),
(16, 'Salta'),
(17, 'San Juan'),
(18, 'San Luis'),
(19, 'Santa Cruz'),
(20, 'Santa Fe'),
(21, 'Santiago del Estero'),
(22, 'Tierra del Fuego'),
(23, 'Tucumán');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `turno`
--

CREATE TABLE `turno` (
  `id_turno` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `turno`
--

INSERT INTO `turno` (`id_turno`, `nombre`) VALUES
(1, 'mañana'),
(2, 'siesta'),
(3, 'tarde');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `id_usuario` int(11) NOT NULL,
  `dni` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `usuario` varchar(50) NOT NULL,
  `contraseña` varchar(20) NOT NULL,
  `fecha_nacimiento` datetime NOT NULL,
  `telefono` varchar(15) NOT NULL,
  `correo` varchar(100) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `status` varchar(10) NOT NULL DEFAULT 'si',
  `id_provincia` int(2) NOT NULL,
  `id_ciudad` int(2) NOT NULL,
  `id_perfil` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`id_usuario`, `dni`, `nombre`, `apellido`, `usuario`, `contraseña`, `fecha_nacimiento`, `telefono`, `correo`, `direccion`, `status`, `id_provincia`, `id_ciudad`, `id_perfil`) VALUES
(134, 12345678, 'Melisa', 'Lazcano A', 'sistemas', '123456', '1985-03-14 00:00:00', '1236321490', 'melisa@example.com', 'direccion 1234', 'si', 1, 1, 1),
(135, 87654321, 'Recep', 'Prueba', 'recep1', '123456', '1988-04-12 00:00:00', '0987654321', 'recep@example.com', 'recep direccion 1000', 'si', 1, 2, 4),
(136, 20202020, 'Jose', 'Perez', 'medico1', '123456', '1975-07-07 00:00:00', '2789638901', 'jose.perez@example.com', 'direc203', 'si', 1, 2, 3),
(137, 30303030, 'Carlos', 'Sosa', 'gestor1', '123456', '1980-05-23 00:00:00', '3423549012', 'carlos.sosa@example.com', 'gestordireccion', 'si', 2, 3, 2),
(138, 45450000, 'Juan', 'Gimenez', 'medico2', '123456', '1982-08-15 00:00:00', '6363895263', 'juan.gimenez@example.com', 'medicodosdirec', 'no', 1, 2, 3),
(139, 60606000, 'Hector', 'Salamanca', 'gestor2', '123456', '1990-09-10 00:00:00', '5678901234', 'hector.salamanca@example.com', 'gestor2direc', 'si', 3, 1, 2),
(140, 79999900, 'Maria', 'Perez', 'recep2', '123456', '1987-01-05 00:00:00', '6789012345', 'maria.perez@example.com', 'direccion recepcionista', 'si', 1, 4, 4),
(141, 60655500, 'Joaquin', 'Phoenix', 'medico3', '123456', '1995-10-10 00:00:00', '7890123456', 'joaquin.phoenix@example.com', 'direccion medico tres', 'si', 1, 2, 3),
(142, 23441141, 'Gustavo', 'Freing', 'sistemas2', '123456', '1994-06-14 00:00:00', '8901234567', 'gustavo.freing@example.com', 'pollos hermanos', 'si', 1, 1, 1),
(143, 12345548, 'Carlos', 'Perez', 'carlos.p', '123456', '1980-01-01 00:00:00', '9012345678', 'carlos.p@example.com', 'Calle 1', 'si', 2, 2, 3),
(144, 87654381, 'Ana', 'Gomez', 'ana.g', 'pass123', '1985-01-05 00:00:00', '0123456789', 'ana.gomez@example.com', 'Calle 2', 'si', 3, 3, 4),
(145, 23456789, 'Juan', 'Martinez', 'juan.m', 'pass123', '1990-01-10 00:00:00', '1234567890', 'juan.martinez@example.com', 'Calle 3', 'si', 4, 4, 1),
(146, 34567890, 'Maria', 'Lopez', 'maria.l', 'pass123', '1988-03-03 00:00:00', '2345678901', 'maria.lopez@example.com', 'Calle 4', 'si', 5, 5, 2),
(147, 45678901, 'Luis', 'Torres', 'luis.t', 'pass123', '1985-05-05 00:00:00', '3456789012', 'luis.torres@example.com', 'Calle 5', 'si', 6, 6, 3),
(148, 56789012, 'Pedro', 'Sanchez', 'pedro.s', 'pass123', '1987-07-07 00:00:00', '4567890123', 'pedro.sanchez@example.com', 'Calle 7', 'si', 7, 7, 4),
(149, 123450111, 'Laura', 'Martinez', 'laura.m', 'pass123', '1992-05-15 00:00:00', '1234467890', 'laura.m@example.com', 'Calle A', 'si', 4, 3, 1),
(150, 987654123, 'Martin', 'Gonzalez', 'martin.g', 'pass123', '1990-09-12 00:00:00', '9876543211', 'martin.g@example.com', 'Calle B', 'si', 5, 2, 2),
(151, 112233556, 'Clara', 'Torres', 'clara.t', 'pass123', '1983-11-23 00:00:00', '1122334456', 'clara.t@example.com', 'Calle C', 'si', 3, 5, 3),
(152, 556677990, 'Luis', 'Alvarez', 'luis.a', 'pass123', '1978-02-20 00:00:00', '5566778891', 'luis.a@example.com', 'Calle D', 'si', 7, 8, 4),
(153, 998877332, 'Sofia', 'Lopez', 'sofia.l', 'pass123', '1995-07-09 00:00:00', '9988776656', 'sofia.l@example.com', 'Calle E', 'si', 1, 1, 1),
(154, 445566334, 'Raul', 'Mendez', 'raul.m', 'pass123', '1987-06-03 00:00:00', '4455667789', 'raul.m@example.com', 'Calle F', 'si', 10, 12, 2),
(155, 667788221, 'Patricia', 'Vega', 'patricia.v', 'pass123', '1980-01-25 00:00:00', '6677889901', 'patricia.v@example.com', 'Calle G', 'si', 9, 6, 3),
(156, 334455998, 'Diego', 'Reyes', 'diego.r', 'pass123', '1993-04-10 00:00:00', '3344556678', 'diego.r@example.com', 'Calle H', 'si', 6, 4, 4),
(157, 778899113, 'Camila', 'Garcia', 'camila.g', 'pass123', '1999-03-22 00:00:00', '7788990012', 'camila.g@example.com', 'Calle I', 'si', 12, 14, 1),
(158, 556677334, 'Ricardo', 'Diaz', 'ricardo.d', 'pass123', '1985-12-13 00:00:00', '5566772234', 'ricardo.d@example.com', 'Calle J', 'si', 8, 11, 2);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `cita`
--
ALTER TABLE `cita`
  ADD PRIMARY KEY (`id_cita`),
  ADD KEY `id_paciente` (`id_paciente`),
  ADD KEY `id_medico` (`id_medico`);

--
-- Indices de la tabla `ciudad`
--
ALTER TABLE `ciudad`
  ADD PRIMARY KEY (`id_ciudad`);

--
-- Indices de la tabla `especialidad`
--
ALTER TABLE `especialidad`
  ADD PRIMARY KEY (`id_especialidad`);

--
-- Indices de la tabla `medico`
--
ALTER TABLE `medico`
  ADD PRIMARY KEY (`id_medico`),
  ADD KEY `id_especialidad` (`id_especialidad`),
  ADD KEY `id_usuario` (`id_usuario`),
  ADD KEY `id_turno` (`id_turno`);

--
-- Indices de la tabla `obra_social`
--
ALTER TABLE `obra_social`
  ADD PRIMARY KEY (`id_obra_social`);

--
-- Indices de la tabla `paciente`
--
ALTER TABLE `paciente`
  ADD PRIMARY KEY (`id_paciente`),
  ADD UNIQUE KEY `dni` (`dni`),
  ADD UNIQUE KEY `correo` (`correo`),
  ADD UNIQUE KEY `telefono` (`telefono`),
  ADD KEY `id_obra_social` (`id_obra_social`),
  ADD KEY `id_ciudad` (`id_ciudad`),
  ADD KEY `id_provincia` (`id_provincia`);

--
-- Indices de la tabla `perfil`
--
ALTER TABLE `perfil`
  ADD PRIMARY KEY (`id_perfil`);

--
-- Indices de la tabla `provincia`
--
ALTER TABLE `provincia`
  ADD PRIMARY KEY (`id_provincia`);

--
-- Indices de la tabla `turno`
--
ALTER TABLE `turno`
  ADD PRIMARY KEY (`id_turno`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`id_usuario`),
  ADD UNIQUE KEY `dni` (`dni`),
  ADD UNIQUE KEY `telefono` (`telefono`),
  ADD UNIQUE KEY `correo` (`correo`),
  ADD UNIQUE KEY `dni_2` (`dni`,`usuario`,`telefono`,`correo`),
  ADD UNIQUE KEY `dni_3` (`dni`,`usuario`,`telefono`,`correo`),
  ADD KEY `id_perfil` (`id_perfil`) USING BTREE,
  ADD KEY `FK_usuario_ciudad` (`id_ciudad`),
  ADD KEY `FK_usuario_provincia` (`id_provincia`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cita`
--
ALTER TABLE `cita`
  MODIFY `id_cita` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=122;

--
-- AUTO_INCREMENT de la tabla `ciudad`
--
ALTER TABLE `ciudad`
  MODIFY `id_ciudad` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT de la tabla `especialidad`
--
ALTER TABLE `especialidad`
  MODIFY `id_especialidad` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `medico`
--
ALTER TABLE `medico`
  MODIFY `id_medico` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT de la tabla `obra_social`
--
ALTER TABLE `obra_social`
  MODIFY `id_obra_social` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `paciente`
--
ALTER TABLE `paciente`
  MODIFY `id_paciente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=76;

--
-- AUTO_INCREMENT de la tabla `perfil`
--
ALTER TABLE `perfil`
  MODIFY `id_perfil` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `provincia`
--
ALTER TABLE `provincia`
  MODIFY `id_provincia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT de la tabla `turno`
--
ALTER TABLE `turno`
  MODIFY `id_turno` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `id_usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=159;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `cita`
--
ALTER TABLE `cita`
  ADD CONSTRAINT `cita_ibfk_1` FOREIGN KEY (`id_paciente`) REFERENCES `paciente` (`id_paciente`),
  ADD CONSTRAINT `cita_ibfk_2` FOREIGN KEY (`id_medico`) REFERENCES `medico` (`id_medico`);

--
-- Filtros para la tabla `medico`
--
ALTER TABLE `medico`
  ADD CONSTRAINT `medico_ibfk_1` FOREIGN KEY (`id_especialidad`) REFERENCES `especialidad` (`id_especialidad`),
  ADD CONSTRAINT `medico_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`),
  ADD CONSTRAINT `medico_ibfk_3` FOREIGN KEY (`id_turno`) REFERENCES `turno` (`id_turno`);

--
-- Filtros para la tabla `paciente`
--
ALTER TABLE `paciente`
  ADD CONSTRAINT `paciente_ibfk_1` FOREIGN KEY (`id_obra_social`) REFERENCES `obra_social` (`id_obra_social`),
  ADD CONSTRAINT `paciente_ibfk_2` FOREIGN KEY (`id_ciudad`) REFERENCES `ciudad` (`id_ciudad`),
  ADD CONSTRAINT `paciente_ibfk_3` FOREIGN KEY (`id_provincia`) REFERENCES `provincia` (`id_provincia`);

--
-- Filtros para la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD CONSTRAINT `FK_usuario_ciudad` FOREIGN KEY (`id_ciudad`) REFERENCES `ciudad` (`id_ciudad`),
  ADD CONSTRAINT `FK_usuario_provincia` FOREIGN KEY (`id_provincia`) REFERENCES `provincia` (`id_provincia`),
  ADD CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`id_perfil`) REFERENCES `perfil` (`id_perfil`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

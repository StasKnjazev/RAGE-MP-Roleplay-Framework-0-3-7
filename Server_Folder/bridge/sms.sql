/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 80012
Source Host           : localhost:3306
Source Database       : empire

Target Server Type    : MYSQL
Target Server Version : 80012
File Encoding         : 65001

Date: 2018-12-30 18:11:27
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for sms
-- ----------------------------
DROP TABLE IF EXISTS `sms`;
CREATE TABLE `sms` (
  `id` int(12) NOT NULL AUTO_INCREMENT,
  `time` datetime DEFAULT NULL,
  `send_from_id` int(12) DEFAULT NULL,
  `send_from_name` varchar(64) DEFAULT NULL,
  `send_to_id` int(12) DEFAULT NULL,
  `send_to_name` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `message` varchar(224) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of sms
-- ----------------------------
INSERT INTO `sms` VALUES ('22', null, '406005', 'Mike Skoting', '406005', 'Mike Skoting', 'yeyed saddas d');
INSERT INTO `sms` VALUES ('23', null, '406005', 'Mike Skoting', '406005', 'Mike Skoting', '15151');

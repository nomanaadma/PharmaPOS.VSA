/*
 Navicat Premium Dump SQL

 Source Server         : Local Postgres
 Source Server Type    : PostgreSQL
 Source Server Version : 180001 (180001)
 Source Host           : localhost:5432
 Source Catalog        : pharmapos
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 180001 (180001)
 File Encoding         : 65001

 Date: 03/10/2026 15:27:10
*/


-- ----------------------------
-- Sequence structure for AspNetRoleClaims_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."AspNetRoleClaims_Id_seq";
CREATE SEQUENCE "public"."AspNetRoleClaims_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for AspNetRoleClaims_Id_seq1
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."AspNetRoleClaims_Id_seq1";
CREATE SEQUENCE "public"."AspNetRoleClaims_Id_seq1" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for AspNetUserClaims_Id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."AspNetUserClaims_Id_seq";
CREATE SEQUENCE "public"."AspNetUserClaims_Id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for AspNetUserClaims_Id_seq1
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."AspNetUserClaims_Id_seq1";
CREATE SEQUENCE "public"."AspNetUserClaims_Id_seq1" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for bill_items_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."bill_items_id_seq";
CREATE SEQUENCE "public"."bill_items_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for bill_items_id_seq1
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."bill_items_id_seq1";
CREATE SEQUENCE "public"."bill_items_id_seq1" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for customers_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."customers_id_seq";
CREATE SEQUENCE "public"."customers_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for customers_id_seq1
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."customers_id_seq1";
CREATE SEQUENCE "public"."customers_id_seq1" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for media_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."media_id_seq";
CREATE SEQUENCE "public"."media_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for media_id_seq1
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."media_id_seq1";
CREATE SEQUENCE "public"."media_id_seq1" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for medicine_batch_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."medicine_batch_id_seq";
CREATE SEQUENCE "public"."medicine_batch_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for medicine_batch_id_seq1
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."medicine_batch_id_seq1";
CREATE SEQUENCE "public"."medicine_batch_id_seq1" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for medicine_bill_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."medicine_bill_id_seq";
CREATE SEQUENCE "public"."medicine_bill_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for medicine_bill_id_seq1
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."medicine_bill_id_seq1";
CREATE SEQUENCE "public"."medicine_bill_id_seq1" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for medicine_categories_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."medicine_categories_id_seq";
CREATE SEQUENCE "public"."medicine_categories_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for medicine_categories_id_seq1
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."medicine_categories_id_seq1";
CREATE SEQUENCE "public"."medicine_categories_id_seq1" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for medicine_purchase_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."medicine_purchase_id_seq";
CREATE SEQUENCE "public"."medicine_purchase_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for medicine_purchase_id_seq1
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."medicine_purchase_id_seq1";
CREATE SEQUENCE "public"."medicine_purchase_id_seq1" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for medicines_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."medicines_id_seq";
CREATE SEQUENCE "public"."medicines_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for medicines_id_seq1
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."medicines_id_seq1";
CREATE SEQUENCE "public"."medicines_id_seq1" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for payment_method_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."payment_method_id_seq";
CREATE SEQUENCE "public"."payment_method_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for payment_method_id_seq1
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."payment_method_id_seq1";
CREATE SEQUENCE "public"."payment_method_id_seq1" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for settings_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."settings_id_seq";
CREATE SEQUENCE "public"."settings_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for settings_id_seq1
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."settings_id_seq1";
CREATE SEQUENCE "public"."settings_id_seq1" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for suppliers_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."suppliers_id_seq";
CREATE SEQUENCE "public"."suppliers_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for suppliers_id_seq1
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."suppliers_id_seq1";
CREATE SEQUENCE "public"."suppliers_id_seq1" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Table structure for AspNetRoleClaims
-- ----------------------------
DROP TABLE IF EXISTS "public"."AspNetRoleClaims";
CREATE TABLE "public"."AspNetRoleClaims" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1
),
  "RoleId" text COLLATE "pg_catalog"."default" NOT NULL,
  "ClaimType" text COLLATE "pg_catalog"."default",
  "ClaimValue" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of AspNetRoleClaims
-- ----------------------------
INSERT INTO "public"."AspNetRoleClaims" VALUES (1, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'dashboard');
INSERT INTO "public"."AspNetRoleClaims" VALUES (2, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'customers');
INSERT INTO "public"."AspNetRoleClaims" VALUES (3, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'customer/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (4, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'customer/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (5, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'customer/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (6, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'customer/view');
INSERT INTO "public"."AspNetRoleClaims" VALUES (7, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/billing');
INSERT INTO "public"."AspNetRoleClaims" VALUES (8, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/billing/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (9, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/billing/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (10, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/billing/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (11, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/billing/view');
INSERT INTO "public"."AspNetRoleClaims" VALUES (12, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/purchase');
INSERT INTO "public"."AspNetRoleClaims" VALUES (13, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/purchase/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (14, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/purchase/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (15, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/purchase/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (16, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/purchase/view');
INSERT INTO "public"."AspNetRoleClaims" VALUES (17, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/stock');
INSERT INTO "public"."AspNetRoleClaims" VALUES (18, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/stock/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (19, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicines');
INSERT INTO "public"."AspNetRoleClaims" VALUES (20, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (21, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (22, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (23, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/view');
INSERT INTO "public"."AspNetRoleClaims" VALUES (24, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/category');
INSERT INTO "public"."AspNetRoleClaims" VALUES (25, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/category/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (26, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/category/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (27, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'medicine/category/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (29, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'users');
INSERT INTO "public"."AspNetRoleClaims" VALUES (30, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'user/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (31, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'user/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (32, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'user/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (33, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'info');
INSERT INTO "public"."AspNetRoleClaims" VALUES (34, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'tax');
INSERT INTO "public"."AspNetRoleClaims" VALUES (35, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'tax/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (36, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'tax/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (37, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'tax/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (38, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'paymentmethod');
INSERT INTO "public"."AspNetRoleClaims" VALUES (39, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'paymentmethod/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (40, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'paymentmethod/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (41, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'paymentmethod/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (42, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'get/media');
INSERT INTO "public"."AspNetRoleClaims" VALUES (43, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'media/upload');
INSERT INTO "public"."AspNetRoleClaims" VALUES (44, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'media/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (183, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'CreatedDate', '	10/01/2018');
INSERT INTO "public"."AspNetRoleClaims" VALUES (184, '0abfbe31-9895-4a96-9688-856f55ef68f9', 'CreatedDate', '24/10/2019');
INSERT INTO "public"."AspNetRoleClaims" VALUES (28, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'reports');
INSERT INTO "public"."AspNetRoleClaims" VALUES (94, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'suppliers');
INSERT INTO "public"."AspNetRoleClaims" VALUES (95, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'supplier/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (96, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'supplier/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (97, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Permission', 'supplier/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (98, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Description', 'You can not change Admin role setting');
INSERT INTO "public"."AspNetRoleClaims" VALUES (539, '0abfbe31-9895-4a96-9688-856f55ef68f9', 'Description', 'Employee');
INSERT INTO "public"."AspNetRoleClaims" VALUES (540, '0abfbe31-9895-4a96-9688-856f55ef68f9', 'Permission', 'dashboard');
INSERT INTO "public"."AspNetRoleClaims" VALUES (541, '0abfbe31-9895-4a96-9688-856f55ef68f9', 'Permission', 'customer/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (542, '0abfbe31-9895-4a96-9688-856f55ef68f9', 'Permission', 'customer/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (543, '0abfbe31-9895-4a96-9688-856f55ef68f9', 'Permission', 'customer/view');
INSERT INTO "public"."AspNetRoleClaims" VALUES (544, '0abfbe31-9895-4a96-9688-856f55ef68f9', 'Permission', 'medicine/billing');
INSERT INTO "public"."AspNetRoleClaims" VALUES (545, '0abfbe31-9895-4a96-9688-856f55ef68f9', 'Permission', 'medicine/billing/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (546, '0abfbe31-9895-4a96-9688-856f55ef68f9', 'Permission', 'medicine/billing/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (547, '0abfbe31-9895-4a96-9688-856f55ef68f9', 'Permission', 'medicine/billing/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (548, '0abfbe31-9895-4a96-9688-856f55ef68f9', 'Permission', 'medicine/billing/view');
INSERT INTO "public"."AspNetRoleClaims" VALUES (182, '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'CreatedDate', '10/01/2018');
INSERT INTO "public"."AspNetRoleClaims" VALUES (343, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Description', 'Store Manager');
INSERT INTO "public"."AspNetRoleClaims" VALUES (344, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'dashboard');
INSERT INTO "public"."AspNetRoleClaims" VALUES (345, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'customers');
INSERT INTO "public"."AspNetRoleClaims" VALUES (346, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'customer/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (347, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'customer/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (348, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'customer/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (349, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'customer/view');
INSERT INTO "public"."AspNetRoleClaims" VALUES (350, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/billing');
INSERT INTO "public"."AspNetRoleClaims" VALUES (351, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/billing/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (352, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/billing/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (353, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/billing/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (354, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/billing/view');
INSERT INTO "public"."AspNetRoleClaims" VALUES (355, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/purchase');
INSERT INTO "public"."AspNetRoleClaims" VALUES (356, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/purchase/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (357, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/purchase/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (358, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/purchase/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (359, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/purchase/view');
INSERT INTO "public"."AspNetRoleClaims" VALUES (360, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/stock');
INSERT INTO "public"."AspNetRoleClaims" VALUES (361, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/stock/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (362, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicines');
INSERT INTO "public"."AspNetRoleClaims" VALUES (363, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (364, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (365, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (366, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/view');
INSERT INTO "public"."AspNetRoleClaims" VALUES (367, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/category');
INSERT INTO "public"."AspNetRoleClaims" VALUES (368, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/category/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (369, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/category/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (370, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'medicine/category/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (371, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'paymentmethod');
INSERT INTO "public"."AspNetRoleClaims" VALUES (372, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'paymentmethod/add');
INSERT INTO "public"."AspNetRoleClaims" VALUES (373, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'paymentmethod/edit');
INSERT INTO "public"."AspNetRoleClaims" VALUES (374, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'paymentmethod/delete');
INSERT INTO "public"."AspNetRoleClaims" VALUES (375, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'get/media');
INSERT INTO "public"."AspNetRoleClaims" VALUES (376, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'media/upload');
INSERT INTO "public"."AspNetRoleClaims" VALUES (377, 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Permission', 'media/delete');

-- ----------------------------
-- Table structure for AspNetRoles
-- ----------------------------
DROP TABLE IF EXISTS "public"."AspNetRoles";
CREATE TABLE "public"."AspNetRoles" (
  "Id" text COLLATE "pg_catalog"."default" NOT NULL,
  "Name" varchar(256) COLLATE "pg_catalog"."default",
  "NormalizedName" varchar(256) COLLATE "pg_catalog"."default",
  "ConcurrencyStamp" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of AspNetRoles
-- ----------------------------
INSERT INTO "public"."AspNetRoles" VALUES ('6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b', 'Admin', 'ADMIN', '5dba3da3-4a77-4bd6-b693-d9d1758e1818');
INSERT INTO "public"."AspNetRoles" VALUES ('d21d5a0d-33e9-4a98-80d8-5c79290e68b3', 'Store Manager', 'STORE MANAGER', '3c4f527e-ff08-4215-9852-8c21726f49b9');
INSERT INTO "public"."AspNetRoles" VALUES ('0abfbe31-9895-4a96-9688-856f55ef68f9', 'Employee', 'EMPLOYEE', '2656e0e9-324a-42e8-b8fd-f602bf948b01');

-- ----------------------------
-- Table structure for AspNetUserClaims
-- ----------------------------
DROP TABLE IF EXISTS "public"."AspNetUserClaims";
CREATE TABLE "public"."AspNetUserClaims" (
  "Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1
),
  "UserId" text COLLATE "pg_catalog"."default" NOT NULL,
  "ClaimType" text COLLATE "pg_catalog"."default",
  "ClaimValue" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of AspNetUserClaims
-- ----------------------------
INSERT INTO "public"."AspNetUserClaims" VALUES (11, 'b4169ce1-d776-4ca9-ae0f-c655957da5ca', 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname', 'areeb');
INSERT INTO "public"."AspNetUserClaims" VALUES (12, 'b4169ce1-d776-4ca9-ae0f-c655957da5ca', 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname', 'shakeel');
INSERT INTO "public"."AspNetUserClaims" VALUES (15, '89e21d43-0cc3-4508-8a17-1d23d77581b2', 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname', 'Amin');
INSERT INTO "public"."AspNetUserClaims" VALUES (16, '89e21d43-0cc3-4508-8a17-1d23d77581b2', 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname', 'Shoukat');
INSERT INTO "public"."AspNetUserClaims" VALUES (17, '89e21d43-0cc3-4508-8a17-1d23d77581b2', 'Gender', 'Male');
INSERT INTO "public"."AspNetUserClaims" VALUES (14, 'b4169ce1-d776-4ca9-ae0f-c655957da5ca', 'CreatedDate', '07/12/2024');
INSERT INTO "public"."AspNetUserClaims" VALUES (18, '89e21d43-0cc3-4508-8a17-1d23d77581b2', 'CreatedDate', '04/12/2024');
INSERT INTO "public"."AspNetUserClaims" VALUES (19, 'dc779c8f-9ff6-4653-ae10-9149b0ac33d9', 'CreatedDate', '03/12/2024');
INSERT INTO "public"."AspNetUserClaims" VALUES (22, 'dc779c8f-9ff6-4653-ae10-9149b0ac33d9', 'Gender', 'Male');
INSERT INTO "public"."AspNetUserClaims" VALUES (13, 'b4169ce1-d776-4ca9-ae0f-c655957da5ca', 'Gender', 'Male');
INSERT INTO "public"."AspNetUserClaims" VALUES (23, 'f2312013-df9e-47d5-b983-d0eb99362bd1', 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname', 'Syed');
INSERT INTO "public"."AspNetUserClaims" VALUES (24, 'f2312013-df9e-47d5-b983-d0eb99362bd1', 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname', 'Afnan');
INSERT INTO "public"."AspNetUserClaims" VALUES (26, 'f2312013-df9e-47d5-b983-d0eb99362bd1', 'CreatedDate', '08/12/2024');
INSERT INTO "public"."AspNetUserClaims" VALUES (6, 'dc779c8f-9ff6-4653-ae10-9149b0ac33d9', 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname', 'Shoukat');
INSERT INTO "public"."AspNetUserClaims" VALUES (5, 'dc779c8f-9ff6-4653-ae10-9149b0ac33d9', 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname', 'Noman');
INSERT INTO "public"."AspNetUserClaims" VALUES (25, 'f2312013-df9e-47d5-b983-d0eb99362bd1', 'Gender', 'Male');

-- ----------------------------
-- Table structure for AspNetUserLogins
-- ----------------------------
DROP TABLE IF EXISTS "public"."AspNetUserLogins";
CREATE TABLE "public"."AspNetUserLogins" (
  "LoginProvider" varchar(128) COLLATE "pg_catalog"."default" NOT NULL,
  "ProviderKey" varchar(128) COLLATE "pg_catalog"."default" NOT NULL,
  "ProviderDisplayName" text COLLATE "pg_catalog"."default",
  "UserId" text COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of AspNetUserLogins
-- ----------------------------

-- ----------------------------
-- Table structure for AspNetUserRoles
-- ----------------------------
DROP TABLE IF EXISTS "public"."AspNetUserRoles";
CREATE TABLE "public"."AspNetUserRoles" (
  "UserId" text COLLATE "pg_catalog"."default" NOT NULL,
  "RoleId" text COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of AspNetUserRoles
-- ----------------------------
INSERT INTO "public"."AspNetUserRoles" VALUES ('dc779c8f-9ff6-4653-ae10-9149b0ac33d9', '6dca0a6e-cc6b-4c0f-becd-7c7a4174ae1b');
INSERT INTO "public"."AspNetUserRoles" VALUES ('89e21d43-0cc3-4508-8a17-1d23d77581b2', '0abfbe31-9895-4a96-9688-856f55ef68f9');
INSERT INTO "public"."AspNetUserRoles" VALUES ('b4169ce1-d776-4ca9-ae0f-c655957da5ca', 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3');
INSERT INTO "public"."AspNetUserRoles" VALUES ('f2312013-df9e-47d5-b983-d0eb99362bd1', 'd21d5a0d-33e9-4a98-80d8-5c79290e68b3');

-- ----------------------------
-- Table structure for AspNetUserTokens
-- ----------------------------
DROP TABLE IF EXISTS "public"."AspNetUserTokens";
CREATE TABLE "public"."AspNetUserTokens" (
  "UserId" text COLLATE "pg_catalog"."default" NOT NULL,
  "LoginProvider" varchar(128) COLLATE "pg_catalog"."default" NOT NULL,
  "Name" varchar(128) COLLATE "pg_catalog"."default" NOT NULL,
  "Value" text COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of AspNetUserTokens
-- ----------------------------

-- ----------------------------
-- Table structure for AspNetUsers
-- ----------------------------
DROP TABLE IF EXISTS "public"."AspNetUsers";
CREATE TABLE "public"."AspNetUsers" (
  "Id" text COLLATE "pg_catalog"."default" NOT NULL,
  "UserName" varchar(256) COLLATE "pg_catalog"."default",
  "NormalizedUserName" varchar(256) COLLATE "pg_catalog"."default",
  "Email" varchar(256) COLLATE "pg_catalog"."default",
  "NormalizedEmail" varchar(256) COLLATE "pg_catalog"."default",
  "EmailConfirmed" bool NOT NULL,
  "PasswordHash" text COLLATE "pg_catalog"."default",
  "SecurityStamp" text COLLATE "pg_catalog"."default",
  "ConcurrencyStamp" text COLLATE "pg_catalog"."default",
  "PhoneNumber" text COLLATE "pg_catalog"."default",
  "PhoneNumberConfirmed" bool NOT NULL,
  "TwoFactorEnabled" bool NOT NULL,
  "LockoutEnd" timestamptz(6),
  "LockoutEnabled" bool NOT NULL,
  "AccessFailedCount" int4 NOT NULL
)
;

-- ----------------------------
-- Records of AspNetUsers
-- ----------------------------
INSERT INTO "public"."AspNetUsers" VALUES ('89e21d43-0cc3-4508-8a17-1d23d77581b2', 'aminshoukat4', 'AMINSHOUKAT4', 'aminshoukat4@gmail.com', 'AMINSHOUKAT4@GMAIL.COM', 't', 'AQAAAAIAAYagAAAAEJA3VyGUs8xlcHSPfsbctQ+bESXy/obXG7O2Sc1dgrZykPkYWGjPkwJK1esBtIyjYg==', 'ZSRI2ZNEMYEB3R2ELUB6L2PWTBWCGKND', '004c8a5f-cb5f-4772-98c6-888dd245f830', '03222819054', 'f', 'f', NULL, 't', 0);
INSERT INTO "public"."AspNetUsers" VALUES ('dc779c8f-9ff6-4653-ae10-9149b0ac33d9', 'nomanaadma', 'NOMANAADMA', 'nomanaadma@gmail.com', 'NOMANAADMA@GMAIL.COM', 't', 'AQAAAAIAAYagAAAAEJwA4qPHdV7bTYFERuuNLgdLvRxuMMwN2FA13TCPD7/IHp/ocuT9+ehTGLIr4bcE8A==', 'PYJNIXCFT6SQUSRMDQXMGDRI4XZIBAZG', '4290869e-b66e-4fca-aa07-f1d8fc87714f', '0322269178911', 'f', 'f', NULL, 't', 0);
INSERT INTO "public"."AspNetUsers" VALUES ('f2312013-df9e-47d5-b983-d0eb99362bd1', 'afnan', 'AFNAN', 'afnan@gmail.com', 'AFNAN@GMAIL.COM', 't', 'AQAAAAIAAYagAAAAEKXsikG7YUde1t4b83/wu8MhLWMe2ZcNIJCCkvonLtUDGHEjDSBFpSXxncfjdS5P0Q==', 'UJPVRYBIQ6JMOSUPSOR44TDHKDGVS45P', 'af5493c2-c4cf-4d0a-b94e-50e96d7039e3', '03222819054123', 'f', 'f', NULL, 't', 0);
INSERT INTO "public"."AspNetUsers" VALUES ('b4169ce1-d776-4ca9-ae0f-c655957da5ca', 'areeb120', 'AREEB120', 'areebshakeel120@gmail.com', 'AREEBSHAKEEL120@GMAIL.COM', 't', 'AQAAAAIAAYagAAAAEKQz234vIcN62FLaWi6iizF//13gSsTECK9nyT1P52CHKjtMNLGxa7htclZuxJMbnQ==', 'TYAEU72IJYDJVIIWUVZ66HAAE7BMQKDX', 'f05669c6-25f6-4d5b-9707-6204d47c378b', '03008911760', 'f', 'f', NULL, 't', 0);

-- ----------------------------
-- Table structure for OutboxMessages
-- ----------------------------
DROP TABLE IF EXISTS "public"."OutboxMessages";
CREATE TABLE "public"."OutboxMessages" (
  "Id" uuid NOT NULL,
  "Type" varchar(500) COLLATE "pg_catalog"."default" NOT NULL,
  "Content" text COLLATE "pg_catalog"."default" NOT NULL,
  "OccurredOn" timestamptz(6) NOT NULL,
  "ProcessedOn" timestamptz(6),
  "Error" text COLLATE "pg_catalog"."default",
  "RetryCount" int4 NOT NULL DEFAULT 0
)
;

-- ----------------------------
-- Records of OutboxMessages
-- ----------------------------
INSERT INTO "public"."OutboxMessages" VALUES ('013f1493-279d-4831-8d21-33fc5a6620ec', 'PharmaPOS.Domain.BillingAggregate.Events.BillDeletedEvent, PharmaPOS.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '{"CustomerId":491}', '2026-10-02 16:50:31.292918+05', '2026-10-02 16:50:35.578242+05', NULL, 0);
INSERT INTO "public"."OutboxMessages" VALUES ('af262338-1e03-45ee-93ae-49e241fe1b1c', 'PharmaPOS.Domain.BillingAggregate.Events.BillDeletedEvent, PharmaPOS.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '{"CustomerId":473}', '2026-10-02 17:50:14.420339+05', '2026-10-02 17:50:18.485093+05', NULL, 0);
INSERT INTO "public"."OutboxMessages" VALUES ('8bd2b7f6-b6b5-4fa1-a5aa-bd5addab42dc', 'PharmaPOS.Domain.BillingAggregate.Events.BillDeletedEvent, PharmaPOS.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '{"CustomerId":473}', '2026-10-02 17:51:12.435099+05', '2026-10-02 17:51:13.583189+05', NULL, 0);
INSERT INTO "public"."OutboxMessages" VALUES ('166ee26b-7377-4ce0-ba83-ece5c92de39e', 'PharmaPOS.Domain.BillingAggregate.Events.BillDeletedEvent, PharmaPOS.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null', '{"CustomerId":467}', '2026-10-02 18:07:33.272363+05', '2026-10-02 18:07:36.044326+05', NULL, 0);

-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
DROP TABLE IF EXISTS "public"."__EFMigrationsHistory";
CREATE TABLE "public"."__EFMigrationsHistory" (
  "MigrationId" varchar(150) COLLATE "pg_catalog"."default" NOT NULL,
  "ProductVersion" varchar(32) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260613141718_InitialCreate', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260614122116_AddSettingsTable', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260614122908_AddMediaTable', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260615152641_AddSuppliersTable', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260615160108_MakeEmailRequiredAndUniqueForSupplier', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260615181928_AddMedicineCategoriesTable', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260615184637_AddPaymentMethodTable', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260615190155_UpdatePaymentMethodStatusToBoolean', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260622164915_AddCustomerTable', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260624105457_AddMedicinesTable', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260627121513_UpdateBatchStatusColumn', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260706155830_AddMedicineBillAndBillItems', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260624160306_AddPurchaseTables', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260706155830_AddBillAndBillItems', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260820103415_TotalToSubTotalInPurchase', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20260821093731_AddCreatedDateDefault', '10.0.9');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20261002112559_AddOutboxMessages', '10.0.9');

-- ----------------------------
-- Table structure for bill_items
-- ----------------------------
DROP TABLE IF EXISTS "public"."bill_items";
CREATE TABLE "public"."bill_items" (
  "id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1
),
  "bill_id" int4 NOT NULL,
  "medicine_id" int4 NOT NULL,
  "batch" int4 NOT NULL,
  "qty" numeric(10,2) NOT NULL,
  "saleprice" numeric(10,2) NOT NULL,
  "gross" numeric(10,2) NOT NULL,
  "discounttype" int4 NOT NULL,
  "discount" numeric(10,2) NOT NULL,
  "discountvalue" numeric(10,2) NOT NULL,
  "tax" numeric(10,2) NOT NULL,
  "taxprice" numeric(10,2) NOT NULL,
  "price" numeric(10,2) NOT NULL
)
;

-- ----------------------------
-- Records of bill_items
-- ----------------------------
INSERT INTO "public"."bill_items" VALUES (72, 55, 2, 34, 2.00, 250.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 500.00);
INSERT INTO "public"."bill_items" VALUES (73, 56, 8, 37, 2.00, 50.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 100.00);
INSERT INTO "public"."bill_items" VALUES (74, 57, 5, 38, 29.00, 60.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 1740.00);
INSERT INTO "public"."bill_items" VALUES (75, 58, 4, 45, 2.00, 30.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 60.00);
INSERT INTO "public"."bill_items" VALUES (76, 59, 6, 46, 5.00, 50.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 250.00);
INSERT INTO "public"."bill_items" VALUES (77, 60, 2, 32, 20.00, 456.00, 0.00, 1, 20.00, 1824.00, 0.00, 0.00, 7296.00);
INSERT INTO "public"."bill_items" VALUES (78, 61, 8, 37, 5.00, 50.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 250.00);
INSERT INTO "public"."bill_items" VALUES (81, 64, 2, 34, 5.00, 250.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 1250.00);
INSERT INTO "public"."bill_items" VALUES (82, 65, 11, 44, 15.00, 60.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 900.00);
INSERT INTO "public"."bill_items" VALUES (83, 53, 1, 31, 2.00, 30.00, 60.00, 1, 1.00, 0.60, 2.00, 1.19, 60.59);
INSERT INTO "public"."bill_items" VALUES (84, 66, 2, 32, 10.00, 456.00, 4560.00, 2, 6.00, 6.00, 1.00, 45.54, 4599.54);
INSERT INTO "public"."bill_items" VALUES (85, 66, 3, 42, 2.00, 30.00, 60.00, 1, 0.00, 0.00, 0.00, 0.00, 60.00);
INSERT INTO "public"."bill_items" VALUES (1, 54, 10, 35, 12.00, 30.00, 360.00, 1, 0.00, 0.00, 0.00, 0.00, 360.00);
INSERT INTO "public"."bill_items" VALUES (2, 63, 10, 33, 5.00, 30.00, 150.00, 1, 0.00, 0.00, 0.00, 0.00, 150.00);
INSERT INTO "public"."bill_items" VALUES (89, 67, 13, 48, 5.00, 20.00, 100.00, 1, 0.00, 0.00, 0.00, 0.00, 100.00);
INSERT INTO "public"."bill_items" VALUES (90, 68, 4, 49, 1.00, 20.00, 20.00, 1, 1.00, 0.20, 0.00, 0.00, 19.80);
INSERT INTO "public"."bill_items" VALUES (114, 83, 10, 35, 1.00, 30.00, 30.00, 2, 10.00, 10.00, 10.00, 2.00, 22.00);

-- ----------------------------
-- Table structure for customers
-- ----------------------------
DROP TABLE IF EXISTS "public"."customers";
CREATE TABLE "public"."customers" (
  "id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1
),
  "firstname" varchar(100) COLLATE "pg_catalog"."default" NOT NULL,
  "lastname" varchar(100) COLLATE "pg_catalog"."default" NOT NULL,
  "email" varchar(254) COLLATE "pg_catalog"."default" NOT NULL,
  "mobile" varchar(30) COLLATE "pg_catalog"."default" NOT NULL,
  "gender" varchar(20) COLLATE "pg_catalog"."default",
  "status" bool NOT NULL,
  "created_date" timestamptz(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Records of customers
-- ----------------------------
INSERT INTO "public"."customers" VALUES (14, 'Jane', 'Smith', 'jane.smith1@example.com', '5', 'Female', 't', '2023-11-21 10:25:43+05');
INSERT INTO "public"."customers" VALUES (15, 'Michael', 'Brown', 'michael.brown1@example.com', '8', 'Male', 't', '2023-12-02 08:15:30+05');
INSERT INTO "public"."customers" VALUES (16, 'Emily', 'Davis', 'emily.davis1@example.com', '4567890123', 'Female', 't', '2023-10-15 12:05:55+05');
INSERT INTO "public"."customers" VALUES (76, 'Emily', 'Anderson', 'emily@example.com', '4567890123', 'Female', 't', '2023-10-15 12:05:55+05');
INSERT INTO "public"."customers" VALUES (82, 'Isabella', 'Lewis', 'isabella.lewis1@example.com', '5432109876', 'Female', 't', '2023-09-30 11:50:22+05');
INSERT INTO "public"."customers" VALUES (466, 'asf', 'asf', 'test2@gmail.com', '2147483647', '', 't', '2024-12-07 13:40:17+05');
INSERT INTO "public"."customers" VALUES (467, 'Noman1', 'Shoukat1', 'nomanaadma1@gmail.com', '032226917899', 'Female', 't', '2024-12-07 13:54:07+05');
INSERT INTO "public"."customers" VALUES (468, 'Muhammad ', 'Arif', 'aarifahmad135@gmail.com', '03008911760', 'Male', 't', '2024-12-07 21:10:16+05');
INSERT INTO "public"."customers" VALUES (469, 'BASHIR', 'BASHIR', 'BASHIR@email.com', '1231231231', '', 't', '2024-12-07 21:14:05+05');
INSERT INTO "public"."customers" VALUES (470, 'hamza', 'hamza', 'hamza@email.com', '1231231231', '', 't', '2024-12-07 21:16:43+05');
INSERT INTO "public"."customers" VALUES (471, 'moiz', 'moiz', 'moiz@email.com', '12312312312', '', 't', '2024-12-07 21:17:23+05');
INSERT INTO "public"."customers" VALUES (472, 'Arif', 'hamed', 'arif@email.com', '123123123', '', 't', '2024-12-07 21:18:04+05');
INSERT INTO "public"."customers" VALUES (473, 'Ramzan', 'Ramzan', 'ramzan@gmail.com', '12345678', 'Male', 't', '2024-12-08 10:46:33+05');

-- ----------------------------
-- Table structure for media
-- ----------------------------
DROP TABLE IF EXISTS "public"."media";
CREATE TABLE "public"."media" (
  "id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1
),
  "media" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "ext" varchar(10) COLLATE "pg_catalog"."default" NOT NULL,
  "created_date" timestamptz(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Records of media
-- ----------------------------
INSERT INTO "public"."media" VALUES (13, 'media-c0c9beb7.png', 'png', '2026-06-14 22:44:10.713201+05');
INSERT INTO "public"."media" VALUES (14, 'media-6c494144.png', 'png', '2026-06-14 22:44:37.688646+05');
INSERT INTO "public"."media" VALUES (15, 'media-1677255d.jpg', 'jpg', '2026-06-14 22:44:45.602138+05');
INSERT INTO "public"."media" VALUES (16, 'media-137ec537.png', 'png', '2026-06-14 22:44:53.843938+05');

-- ----------------------------
-- Table structure for medicine_batch
-- ----------------------------
DROP TABLE IF EXISTS "public"."medicine_batch";
CREATE TABLE "public"."medicine_batch" (
  "id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1
),
  "batch" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "expiry" varchar(10) COLLATE "pg_catalog"."default" NOT NULL,
  "pqty" varchar(10) COLLATE "pg_catalog"."default",
  "qty" numeric(10,2) NOT NULL,
  "saleprice" numeric(10,2) NOT NULL,
  "purchaseprice" numeric(10,2) NOT NULL,
  "gross" numeric(10,2) NOT NULL,
  "discounttype" int4 NOT NULL,
  "discount" numeric(10,2) NOT NULL,
  "discountvalue" numeric(10,2) NOT NULL,
  "tax" numeric(10,2) NOT NULL,
  "taxprice" numeric(10,2) NOT NULL,
  "price" numeric(10,2) NOT NULL,
  "sold" numeric(10,2) NOT NULL DEFAULT 0.0,
  "medicine_id" int4 NOT NULL,
  "purchase_id" int4 NOT NULL,
  "created_date" timestamptz(6) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "status" bool
)
;

-- ----------------------------
-- Records of medicine_batch
-- ----------------------------
INSERT INTO "public"."medicine_batch" VALUES (36, '10', '01-2027', '10', 20.00, 20.00, 15.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 300.00, 0.00, 7, 29, '2024-12-07 20:57:00+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (37, '1', '07-2026', '20', 50.00, 50.00, 40.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 2000.00, 7.00, 8, 30, '2024-12-07 20:57:48+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (38, '2', '06-2026', '50', 120.00, 60.00, 46.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 5520.00, 29.00, 5, 31, '2024-12-07 20:58:38+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (42, '6', '09-2026', '10', 25.00, 30.00, 20.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 500.00, 2.00, 3, 35, '2024-12-07 21:05:28+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (43, '7', '10-2026', '10', 25.00, 30.00, 20.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 500.00, 0.00, 3, 36, '2024-12-07 21:05:31+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (44, '2', '01-2027', '20', 30.00, 60.00, 45.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 1350.00, 15.00, 11, 37, '2024-12-07 21:07:32+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (45, '4', '07-2026', '20', 20.00, 30.00, 20.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 400.00, 2.00, 4, 38, '2024-12-07 21:08:19+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (47, '3', '08-2026', '10', 20.00, 35.00, 30.00, 600.00, 1, 0.00, 0.00, 0.00, 0.00, 600.00, 0.00, 2, 40, '2024-12-08 09:26:08+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (31, '123', '07-2026', '', 10.00, 30.00, 20.00, 200.00, 2, 10.00, 10.00, 2.00, 3.80, 193.80, 2.00, 1, 24, '2024-12-07 01:41:15+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (32, '1234', '06-2026', '123', 124.00, 456.00, 123.00, 15252.00, 1, 3.00, 457.56, 4.00, 591.78, 15386.22, 30.00, 2, 25, '2024-12-07 13:51:07+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (48, '123', '09-2026', '10', 20.00, 20.00, 10.00, 200.00, 2, 10.00, 10.00, 2.00, 3.80, 193.80, 5.00, 13, 41, '2024-12-08 10:44:21+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (49, '5555', '07-2027', '1', 20.00, 20.00, 10.00, 200.00, 2, 1.00, 1.00, 0.00, 0.00, 199.00, 1.00, 4, 42, '2026-08-20 16:04:46.106194+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (50, '6666', '08-2028', '2', 2.00, 40.00, 20.00, 40.00, 1, 0.00, 0.00, 0.00, 0.00, 40.00, 0.00, 5, 43, '2026-08-20 16:45:11.56415+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (35, '2', '10-2026', '10', 20.00, 30.00, 13.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 260.00, 13.00, 10, 28, '2024-12-07 20:55:59+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (52, '5555', '03-2027', '10', 12.00, 14.00, 13.00, 156.00, 1, 0.00, 0.00, 0.00, 0.00, 156.00, 0.00, 8, 45, '2026-08-26 19:44:56.879175+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (51, '7776', '07-2027', '10', 10.00, 17.00, 13.00, 130.00, 1, 0.00, 0.00, 0.00, 0.00, 130.00, 0.00, 5, 44, '2026-08-24 18:52:34.397957+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (46, '8', '09-2026', '10', 28.00, 50.00, 43.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 1204.00, 14.00, 6, 39, '2024-12-07 21:09:01+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (34, '2', '09-2026', '100', 10.00, 250.00, 200.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 2000.00, 7.00, 2, 27, '2024-12-07 20:55:12+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (56, '5555', '07-2027', '200', 200.00, 400.00, 200.00, 40000.00, 1, 0.00, 0.00, 0.00, 0.00, 40000.00, 0.00, 11, 49, '2026-09-02 18:14:07.870146+05', 't');
INSERT INTO "public"."medicine_batch" VALUES (33, '1', '11-2026', '15', 10.00, 30.00, 20.00, 0.00, 1, 0.00, 0.00, 0.00, 0.00, 200.00, 5.00, 10, 26, '2024-12-07 20:53:58+05', 't');

-- ----------------------------
-- Table structure for medicine_bill
-- ----------------------------
DROP TABLE IF EXISTS "public"."medicine_bill";
CREATE TABLE "public"."medicine_bill" (
  "id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1
),
  "customer_id" int4 NOT NULL,
  "name" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "email" varchar(254) COLLATE "pg_catalog"."default",
  "mobile" varchar(30) COLLATE "pg_catalog"."default",
  "method" int4 NOT NULL,
  "bill_date" date NOT NULL,
  "subtotal" numeric(10,2) NOT NULL,
  "tax" numeric(10,2) NOT NULL,
  "discount_value" numeric(10,2) NOT NULL,
  "amount" numeric(10,2) NOT NULL,
  "note" text COLLATE "pg_catalog"."default",
  "created_date" timestamptz(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Records of medicine_bill
-- ----------------------------
INSERT INTO "public"."medicine_bill" VALUES (53, 466, 'asf', 'test2@gmail.com', '2147483647', 1, '2024-12-07', 150.00, 3.44, 15.60, 137.84, '', '2024-12-07 03:26:07+05');
INSERT INTO "public"."medicine_bill" VALUES (55, 468, 'Muhammad  Arif', 'aarifahmad135@gmail.com', '2147483647', 1, '2024-12-02', 500.00, 0.00, 0.00, 500.00, '', '2024-12-07 21:10:43+05');
INSERT INTO "public"."medicine_bill" VALUES (56, 16, 'Emily Davis', 'emily.davis1@example.com', '2147483647', 1, '2024-12-07', 100.00, 0.00, 0.00, 100.00, '', '2024-12-07 21:11:19+05');
INSERT INTO "public"."medicine_bill" VALUES (57, 82, 'Isabella Lewis', 'isabella.lewis1@example.com', '2147483647', 2, '2024-12-07', 1740.00, 0.00, 0.00, 1740.00, '', '2024-12-07 21:12:17+05');
INSERT INTO "public"."medicine_bill" VALUES (58, 82, 'Isabella Lewis', 'isabella.lewis1@example.com', '2147483647', 1, '2024-12-07', 60.00, 0.00, 0.00, 60.00, '', '2024-12-07 21:13:15+05');
INSERT INTO "public"."medicine_bill" VALUES (59, 469, 'BASHIR', 'BASHIR@email.com', '1231231231', 1, '2024-12-07', 250.00, 0.00, 0.00, 250.00, '', '2024-12-07 21:14:05+05');
INSERT INTO "public"."medicine_bill" VALUES (60, 14, 'Jane Smith', 'jane.smith1@example.com', '5', 1, '2024-12-07', 7296.00, 0.00, 1824.00, 7296.00, '', '2024-12-07 21:15:10+05');
INSERT INTO "public"."medicine_bill" VALUES (61, 15, 'Michael Brown', 'michael.brown1@example.com', '8', 2, '2024-12-07', 250.00, 0.00, 0.00, 250.00, '', '2024-12-07 21:16:09+05');
INSERT INTO "public"."medicine_bill" VALUES (62, 470, 'hamza', 'hamza@email.com', '1231231231', 1, '2024-12-07', 90.00, 0.00, 0.00, 90.00, '', '2024-12-07 21:16:43+05');
INSERT INTO "public"."medicine_bill" VALUES (64, 472, 'Arif hamed', 'arif@email.com', '123123123', 1, '2024-12-05', 1250.00, 0.00, 0.00, 1250.00, '', '2024-12-07 21:18:04+05');
INSERT INTO "public"."medicine_bill" VALUES (65, 76, 'Emily Davis', 'emily.davis1@example.com', '2147483647', 1, '2024-12-07', 900.00, 0.00, 0.00, 900.00, '', '2024-12-07 21:20:07+05');
INSERT INTO "public"."medicine_bill" VALUES (66, 471, 'moiz moiz', 'moiz@email.com', '2147483647', 1, '2024-12-08', 4620.00, 45.54, 6.00, 4659.54, '', '2024-12-08 09:23:13+05');
INSERT INTO "public"."medicine_bill" VALUES (54, 467, 'Noman1 Shoukat1', 'nomanaadma1@gmail.com', '2147483647', 1, '2024-12-06', 360.00, 0.00, 0.00, 360.00, NULL, '2024-12-07 21:09:49+05');
INSERT INTO "public"."medicine_bill" VALUES (63, 471, 'moiz', 'moiz@email.com', '2147483647', 2, '2024-12-06', 150.00, 0.00, 0.00, 150.00, NULL, '2024-12-07 21:17:23+05');
INSERT INTO "public"."medicine_bill" VALUES (67, 473, 'Ramzan', 'ramzan@gmail.com', '12345678', 1, '2024-11-28', 100.00, 0.00, 0.00, 100.00, NULL, '2024-12-08 10:46:33+05');
INSERT INTO "public"."medicine_bill" VALUES (68, 467, 'Noman1 Shoukat1', 'nomanaadma1@gmail.com', '032226917899', 1, '2026-08-19', 20.00, 0.00, 0.20, 19.80, NULL, '2026-08-20 16:05:17.038899+05');
INSERT INTO "public"."medicine_bill" VALUES (83, 467, 'Noman1 Shoukat1', 'nomanaadma1@gmail.com', '032226917899', 1, '2026-10-02', 30.00, 2.00, 10.00, 22.00, NULL, '2026-10-02 18:08:10.934488+05');

-- ----------------------------
-- Table structure for medicine_categories
-- ----------------------------
DROP TABLE IF EXISTS "public"."medicine_categories";
CREATE TABLE "public"."medicine_categories" (
  "id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1
),
  "name" varchar(100) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of medicine_categories
-- ----------------------------
INSERT INTO "public"."medicine_categories" VALUES (1, 'Tablet');
INSERT INTO "public"."medicine_categories" VALUES (2, 'Syrup');
INSERT INTO "public"."medicine_categories" VALUES (3, 'Liquid');
INSERT INTO "public"."medicine_categories" VALUES (11, 'adsfadsf');

-- ----------------------------
-- Table structure for medicine_purchase
-- ----------------------------
DROP TABLE IF EXISTS "public"."medicine_purchase";
CREATE TABLE "public"."medicine_purchase" (
  "id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1
),
  "supplier" int4 NOT NULL,
  "date" date NOT NULL,
  "sub_total" numeric(10,2) NOT NULL,
  "tax" numeric(10,2) NOT NULL,
  "discount_value" numeric(10,2) NOT NULL,
  "amount" numeric(10,2) NOT NULL,
  "note" text COLLATE "pg_catalog"."default",
  "created_date" timestamptz(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Records of medicine_purchase
-- ----------------------------
INSERT INTO "public"."medicine_purchase" VALUES (24, 1, '2024-12-07', 200.00, 3.80, 10.00, 193.80, '', '2024-12-07 01:41:15+05');
INSERT INTO "public"."medicine_purchase" VALUES (25, 1, '2024-12-07', 15252.00, 591.78, 457.56, 15386.22, '', '2024-12-07 13:51:07+05');
INSERT INTO "public"."medicine_purchase" VALUES (26, 3, '2024-12-04', 200.00, 0.00, 0.00, 200.00, '', '2024-12-07 20:53:58+05');
INSERT INTO "public"."medicine_purchase" VALUES (27, 4, '2024-12-04', 2000.00, 0.00, 0.00, 2000.00, '', '2024-12-07 20:55:12+05');
INSERT INTO "public"."medicine_purchase" VALUES (28, 5, '2024-12-07', 260.00, 0.00, 0.00, 260.00, '', '2024-12-07 20:55:59+05');
INSERT INTO "public"."medicine_purchase" VALUES (29, 6, '2024-11-30', 300.00, 0.00, 0.00, 300.00, '', '2024-12-07 20:57:00+05');
INSERT INTO "public"."medicine_purchase" VALUES (30, 6, '2024-12-04', 2000.00, 0.00, 0.00, 2000.00, '', '2024-12-07 20:57:48+05');
INSERT INTO "public"."medicine_purchase" VALUES (31, 4, '2024-12-05', 5520.00, 0.00, 0.00, 5520.00, '', '2024-12-07 20:58:38+05');
INSERT INTO "public"."medicine_purchase" VALUES (34, 3, '2024-11-08', 3015.00, 0.00, 0.00, 3015.00, '', '2024-12-07 21:04:35+05');
INSERT INTO "public"."medicine_purchase" VALUES (36, 3, '2024-12-03', 500.00, 0.00, 0.00, 500.00, '', '2024-12-07 21:05:31+05');
INSERT INTO "public"."medicine_purchase" VALUES (37, 1, '2024-12-01', 7621.00, 0.00, 0.00, 7621.00, '', '2024-12-07 21:07:32+05');
INSERT INTO "public"."medicine_purchase" VALUES (38, 6, '2024-11-09', 400.00, 0.00, 0.00, 400.00, '', '2024-12-07 21:08:19+05');
INSERT INTO "public"."medicine_purchase" VALUES (39, 4, '2024-12-07', 1204.00, 0.00, 0.00, 1204.00, '', '2024-12-07 21:09:01+05');
INSERT INTO "public"."medicine_purchase" VALUES (40, 4, '2024-12-08', 600.00, 0.00, 0.00, 600.00, '', '2024-12-08 09:26:08+05');
INSERT INTO "public"."medicine_purchase" VALUES (35, 3, '2024-12-03', 500.00, 0.00, 0.00, 500.00, NULL, '2024-12-07 21:05:28+05');
INSERT INTO "public"."medicine_purchase" VALUES (42, 3, '2026-08-20', 200.00, 0.00, 1.00, 199.00, NULL, '2026-08-20 16:04:46.019121+05');
INSERT INTO "public"."medicine_purchase" VALUES (43, 6, '2026-08-20', 40.00, 0.00, 0.00, 40.00, NULL, '2026-08-20 16:45:11.526593+05');
INSERT INTO "public"."medicine_purchase" VALUES (44, 3, '2026-08-24', 130.00, 0.00, 0.00, 130.00, 'dfd', '2026-08-24 18:52:34.397957+05');
INSERT INTO "public"."medicine_purchase" VALUES (45, 3, '2026-08-26', 156.00, 0.00, 0.00, 156.00, NULL, '2026-08-26 19:44:56.879175+05');
INSERT INTO "public"."medicine_purchase" VALUES (49, 5, '2026-09-02', 40000.00, 0.00, 0.00, 40000.00, NULL, '2026-09-02 18:14:07.870146+05');
INSERT INTO "public"."medicine_purchase" VALUES (41, 1, '2024-12-08', 200.00, 3.80, 10.00, 193.80, 'abc', '2024-12-08 10:44:21+05');

-- ----------------------------
-- Table structure for medicines
-- ----------------------------
DROP TABLE IF EXISTS "public"."medicines";
CREATE TABLE "public"."medicines" (
  "id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1
),
  "name" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "company" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "generic" text COLLATE "pg_catalog"."default" NOT NULL,
  "medicine_group" varchar(255) COLLATE "pg_catalog"."default",
  "category" int4 NOT NULL,
  "storebox" varchar(255) COLLATE "pg_catalog"."default",
  "minlevel" numeric,
  "reorderlevel" numeric,
  "unit" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "unitpacking" varchar(255) COLLATE "pg_catalog"."default",
  "note" text COLLATE "pg_catalog"."default",
  "created_date" timestamptz(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Records of medicines
-- ----------------------------
INSERT INTO "public"."medicines" VALUES (1, 'Enterogermina', 'Bayer', 'Resfriado', 'Home', 2, '6000', 2, 10, '10', '5000', 'None', '2024-12-04 12:40:02+05');
INSERT INTO "public"."medicines" VALUES (2, 'Panadol', 'Glaxo Smith Kline', 'Resfriado 2', 'Home 2', 1, 'Drawer', 2, 10, '10', '300', '', '2024-12-04 23:46:26+05');
INSERT INTO "public"."medicines" VALUES (3, 'Disprine', 'random', 'Resfriado 2', 'home', 1, '', 10, NULL, '10', '20', '', '2024-12-07 20:41:26+05');
INSERT INTO "public"."medicines" VALUES (4, 'flagyl', 'Random', 'Cough', 'none', 1, 'Rag', 10, NULL, '20', '15', '', '2024-12-07 20:42:29+05');
INSERT INTO "public"."medicines" VALUES (5, 'sancos', 'abbot', 'random', 'Home', 2, 'Box', 10, NULL, '10', '23', '', '2024-12-07 20:43:33+05');
INSERT INTO "public"."medicines" VALUES (6, 'cosome', 'Bosche', 'Random', 'home', 2, '', 2, 1, '10', '10', '', '2024-12-07 20:44:40+05');
INSERT INTO "public"."medicines" VALUES (7, 'strepsils', 'Abbot', 'Abc', 'abc', 1, 'Box', 10, 5, '30', '20', '', '2024-12-07 20:47:19+05');
INSERT INTO "public"."medicines" VALUES (8, 'caflam', 'Getz', 'head', 'random', 1, 'Drawer', 4, 5, '20', '15', '', '2024-12-07 20:48:17+05');
INSERT INTO "public"."medicines" VALUES (10, 'Pandol CF', 'abbot', 'none', 'none', 1, 'box', 2, 5, '30', '10', '', '2024-12-07 20:50:48+05');
INSERT INTO "public"."medicines" VALUES (11, 'ascad', 'Getz', 'Random', 'Random', 1, 'box', 10, 5, '50', '20', '', '2024-12-07 20:51:52+05');
INSERT INTO "public"."medicines" VALUES (12, 'Angiseds', 'GSK', 'Randoms', 'randoms', 3, 'Drawer', 6, 3, '10', '20', NULL, '2024-12-07 20:53:15+05');
INSERT INTO "public"."medicines" VALUES (13, 'paracetamol', 'glaxo smith kline', 'formula', NULL, 1, NULL, NULL, NULL, '10', NULL, NULL, '2024-12-08 10:38:14+05');

-- ----------------------------
-- Table structure for payment_method
-- ----------------------------
DROP TABLE IF EXISTS "public"."payment_method";
CREATE TABLE "public"."payment_method" (
  "id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1
),
  "name" varchar(100) COLLATE "pg_catalog"."default" NOT NULL,
  "created_date" timestamptz(6) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  "status" bool NOT NULL DEFAULT true
)
;

-- ----------------------------
-- Records of payment_method
-- ----------------------------
INSERT INTO "public"."payment_method" VALUES (1, 'Cash Payment', '2024-12-04 12:45:30+05', 't');
INSERT INTO "public"."payment_method" VALUES (2, 'Card Payment', '2024-12-04 12:45:37+05', 't');

-- ----------------------------
-- Table structure for settings
-- ----------------------------
DROP TABLE IF EXISTS "public"."settings";
CREATE TABLE "public"."settings" (
  "id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1
),
  "logo" varchar(255) COLLATE "pg_catalog"."default",
  "logo_icon" varchar(255) COLLATE "pg_catalog"."default",
  "lg_background" varchar(255) COLLATE "pg_catalog"."default",
  "favicon" varchar(255) COLLATE "pg_catalog"."default",
  "name" varchar(150) COLLATE "pg_catalog"."default" NOT NULL,
  "legal_name" varchar(200) COLLATE "pg_catalog"."default" NOT NULL,
  "mail" varchar(254) COLLATE "pg_catalog"."default" NOT NULL,
  "phone" varchar(30) COLLATE "pg_catalog"."default" NOT NULL,
  "city" varchar(100) COLLATE "pg_catalog"."default",
  "country" varchar(100) COLLATE "pg_catalog"."default",
  "address_line1" varchar(200) COLLATE "pg_catalog"."default",
  "address_line2" varchar(200) COLLATE "pg_catalog"."default",
  "postal" varchar(20) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of settings
-- ----------------------------
INSERT INTO "public"."settings" VALUES (2, 'media-c0c9beb7.png', 'media-6c494144.png', 'media-1677255d.jpg', 'media-137ec537.png', 'PharmaPOS Storeaaas', 'PharmaPOS Store LLCcs', 'store@pharmapos.comb', '1234567890d', 'karachi', 'Country', 'Address Line 11', 'Address Line 2', '74550');

-- ----------------------------
-- Table structure for suppliers
-- ----------------------------
DROP TABLE IF EXISTS "public"."suppliers";
CREATE TABLE "public"."suppliers" (
  "id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1
),
  "name" varchar(150) COLLATE "pg_catalog"."default" NOT NULL,
  "email" varchar(254) COLLATE "pg_catalog"."default" NOT NULL DEFAULT ''::character varying,
  "phone" varchar(30) COLLATE "pg_catalog"."default" NOT NULL,
  "address" varchar(500) COLLATE "pg_catalog"."default",
  "created_date" timestamptz(6) NOT NULL DEFAULT CURRENT_TIMESTAMP
)
;

-- ----------------------------
-- Records of suppliers
-- ----------------------------
INSERT INTO "public"."suppliers" VALUES (1, 'Galaxy Pharma', 'galaxypharma@gmail.com', '090078601', 'Karachi', '2024-12-04 12:47:13+05');
INSERT INTO "public"."suppliers" VALUES (3, 'Abbot agent', 'abbot_agent@email.com', '123123123', '', '2024-12-07 20:38:32+05');
INSERT INTO "public"."suppliers" VALUES (4, 'Time medicons', 'time@email.com', '123123123', '', '2024-12-07 20:38:50+05');
INSERT INTO "public"."suppliers" VALUES (5, 'Bismillah medical agent', 'bma@email.com', '12312312312', 'Karachi', '2024-12-07 20:39:31+05');
INSERT INTO "public"."suppliers" VALUES (6, 'Dvago agent', 'dva_agent@email.com', '12312312', '', '2024-12-07 20:40:10+05');

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."AspNetRoleClaims_Id_seq"
OWNED BY "public"."AspNetRoleClaims"."Id";
SELECT setval('"public"."AspNetRoleClaims_Id_seq"', 184, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."AspNetRoleClaims_Id_seq1"
OWNED BY "public"."AspNetRoleClaims"."Id";
SELECT setval('"public"."AspNetRoleClaims_Id_seq1"', 548, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."AspNetUserClaims_Id_seq"
OWNED BY "public"."AspNetUserClaims"."Id";
SELECT setval('"public"."AspNetUserClaims_Id_seq"', 26, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."AspNetUserClaims_Id_seq1"
OWNED BY "public"."AspNetUserClaims"."Id";
SELECT setval('"public"."AspNetUserClaims_Id_seq1"', 26, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."bill_items_id_seq"
OWNED BY "public"."bill_items"."id";
SELECT setval('"public"."bill_items_id_seq"', 2, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."bill_items_id_seq1"
OWNED BY "public"."bill_items"."id";
SELECT setval('"public"."bill_items_id_seq1"', 114, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."customers_id_seq"
OWNED BY "public"."customers"."id";
SELECT setval('"public"."customers_id_seq"', 5, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."customers_id_seq1"
OWNED BY "public"."customers"."id";
SELECT setval('"public"."customers_id_seq1"', 491, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."media_id_seq"
OWNED BY "public"."media"."id";
SELECT setval('"public"."media_id_seq"', 17, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."media_id_seq1"
OWNED BY "public"."media"."id";
SELECT setval('"public"."media_id_seq1"', 21, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."medicine_batch_id_seq"
OWNED BY "public"."medicine_batch"."id";
SELECT setval('"public"."medicine_batch_id_seq"', 5, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."medicine_batch_id_seq1"
OWNED BY "public"."medicine_batch"."id";
SELECT setval('"public"."medicine_batch_id_seq1"', 57, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."medicine_bill_id_seq"
OWNED BY "public"."medicine_bill"."id";
SELECT setval('"public"."medicine_bill_id_seq"', 1, false);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."medicine_bill_id_seq1"
OWNED BY "public"."medicine_bill"."id";
SELECT setval('"public"."medicine_bill_id_seq1"', 83, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."medicine_categories_id_seq"
OWNED BY "public"."medicine_categories"."id";
SELECT setval('"public"."medicine_categories_id_seq"', 2, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."medicine_categories_id_seq1"
OWNED BY "public"."medicine_categories"."id";
SELECT setval('"public"."medicine_categories_id_seq1"', 12, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."medicine_purchase_id_seq"
OWNED BY "public"."medicine_purchase"."id";
SELECT setval('"public"."medicine_purchase_id_seq"', 2, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."medicine_purchase_id_seq1"
OWNED BY "public"."medicine_purchase"."id";
SELECT setval('"public"."medicine_purchase_id_seq1"', 50, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."medicines_id_seq"
OWNED BY "public"."medicines"."id";
SELECT setval('"public"."medicines_id_seq"', 1, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."medicines_id_seq1"
OWNED BY "public"."medicines"."id";
SELECT setval('"public"."medicines_id_seq1"', 13, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."payment_method_id_seq"
OWNED BY "public"."payment_method"."id";
SELECT setval('"public"."payment_method_id_seq"', 3, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."payment_method_id_seq1"
OWNED BY "public"."payment_method"."id";
SELECT setval('"public"."payment_method_id_seq1"', 8, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."settings_id_seq"
OWNED BY "public"."settings"."id";
SELECT setval('"public"."settings_id_seq"', 2, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."settings_id_seq1"
OWNED BY "public"."settings"."id";
SELECT setval('"public"."settings_id_seq1"', 2, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."suppliers_id_seq"
OWNED BY "public"."suppliers"."id";
SELECT setval('"public"."suppliers_id_seq"', 2, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."suppliers_id_seq1"
OWNED BY "public"."suppliers"."id";
SELECT setval('"public"."suppliers_id_seq1"', 13, true);

-- ----------------------------
-- Auto increment value for AspNetRoleClaims
-- ----------------------------
SELECT setval('"public"."AspNetRoleClaims_Id_seq1"', 548, true);

-- ----------------------------
-- Indexes structure for table AspNetRoleClaims
-- ----------------------------
CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "public"."AspNetRoleClaims" USING btree (
  "RoleId" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table AspNetRoleClaims
-- ----------------------------
ALTER TABLE "public"."AspNetRoleClaims" ADD CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table AspNetRoles
-- ----------------------------
CREATE UNIQUE INDEX "RoleNameIndex" ON "public"."AspNetRoles" USING btree (
  "NormalizedName" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table AspNetRoles
-- ----------------------------
ALTER TABLE "public"."AspNetRoles" ADD CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id");

-- ----------------------------
-- Auto increment value for AspNetUserClaims
-- ----------------------------
SELECT setval('"public"."AspNetUserClaims_Id_seq1"', 26, true);

-- ----------------------------
-- Indexes structure for table AspNetUserClaims
-- ----------------------------
CREATE INDEX "IX_AspNetUserClaims_UserId" ON "public"."AspNetUserClaims" USING btree (
  "UserId" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table AspNetUserClaims
-- ----------------------------
ALTER TABLE "public"."AspNetUserClaims" ADD CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table AspNetUserLogins
-- ----------------------------
CREATE INDEX "IX_AspNetUserLogins_UserId" ON "public"."AspNetUserLogins" USING btree (
  "UserId" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table AspNetUserLogins
-- ----------------------------
ALTER TABLE "public"."AspNetUserLogins" ADD CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey");

-- ----------------------------
-- Indexes structure for table AspNetUserRoles
-- ----------------------------
CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "public"."AspNetUserRoles" USING btree (
  "RoleId" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table AspNetUserRoles
-- ----------------------------
ALTER TABLE "public"."AspNetUserRoles" ADD CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId");

-- ----------------------------
-- Primary Key structure for table AspNetUserTokens
-- ----------------------------
ALTER TABLE "public"."AspNetUserTokens" ADD CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name");

-- ----------------------------
-- Indexes structure for table AspNetUsers
-- ----------------------------
CREATE INDEX "EmailIndex" ON "public"."AspNetUsers" USING btree (
  "NormalizedEmail" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);
CREATE UNIQUE INDEX "UserNameIndex" ON "public"."AspNetUsers" USING btree (
  "NormalizedUserName" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table AspNetUsers
-- ----------------------------
ALTER TABLE "public"."AspNetUsers" ADD CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table OutboxMessages
-- ----------------------------
CREATE INDEX "IX_OutboxMessages_Unprocessed" ON "public"."OutboxMessages" USING btree (
  "ProcessedOn" "pg_catalog"."timestamptz_ops" ASC NULLS LAST,
  "RetryCount" "pg_catalog"."int4_ops" ASC NULLS LAST
) WHERE "ProcessedOn" IS NULL;

-- ----------------------------
-- Primary Key structure for table OutboxMessages
-- ----------------------------
ALTER TABLE "public"."OutboxMessages" ADD CONSTRAINT "PK_OutboxMessages" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table __EFMigrationsHistory
-- ----------------------------
ALTER TABLE "public"."__EFMigrationsHistory" ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");

-- ----------------------------
-- Auto increment value for bill_items
-- ----------------------------
SELECT setval('"public"."bill_items_id_seq1"', 114, true);

-- ----------------------------
-- Indexes structure for table bill_items
-- ----------------------------
CREATE INDEX "IX_bill_items_batch" ON "public"."bill_items" USING btree (
  "batch" "pg_catalog"."int4_ops" ASC NULLS LAST
);
CREATE INDEX "IX_bill_items_bill_id" ON "public"."bill_items" USING btree (
  "bill_id" "pg_catalog"."int4_ops" ASC NULLS LAST
);
CREATE INDEX "IX_bill_items_medicine_id" ON "public"."bill_items" USING btree (
  "medicine_id" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table bill_items
-- ----------------------------
ALTER TABLE "public"."bill_items" ADD CONSTRAINT "PK_bill_items" PRIMARY KEY ("id");

-- ----------------------------
-- Auto increment value for customers
-- ----------------------------
SELECT setval('"public"."customers_id_seq1"', 491, true);

-- ----------------------------
-- Indexes structure for table customers
-- ----------------------------
CREATE UNIQUE INDEX "IX_customers_email" ON "public"."customers" USING btree (
  "email" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table customers
-- ----------------------------
ALTER TABLE "public"."customers" ADD CONSTRAINT "PK_customers" PRIMARY KEY ("id");

-- ----------------------------
-- Auto increment value for media
-- ----------------------------
SELECT setval('"public"."media_id_seq1"', 21, true);

-- ----------------------------
-- Primary Key structure for table media
-- ----------------------------
ALTER TABLE "public"."media" ADD CONSTRAINT "PK_media" PRIMARY KEY ("id");

-- ----------------------------
-- Auto increment value for medicine_batch
-- ----------------------------
SELECT setval('"public"."medicine_batch_id_seq1"', 57, true);

-- ----------------------------
-- Indexes structure for table medicine_batch
-- ----------------------------
CREATE INDEX "IX_medicine_batch_medicine_id" ON "public"."medicine_batch" USING btree (
  "medicine_id" "pg_catalog"."int4_ops" ASC NULLS LAST
);
CREATE INDEX "IX_medicine_batch_purchase_id" ON "public"."medicine_batch" USING btree (
  "purchase_id" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table medicine_batch
-- ----------------------------
ALTER TABLE "public"."medicine_batch" ADD CONSTRAINT "PK_medicine_batch" PRIMARY KEY ("id");

-- ----------------------------
-- Auto increment value for medicine_bill
-- ----------------------------
SELECT setval('"public"."medicine_bill_id_seq1"', 83, true);

-- ----------------------------
-- Indexes structure for table medicine_bill
-- ----------------------------
CREATE INDEX "IX_medicine_bill_customer_id" ON "public"."medicine_bill" USING btree (
  "customer_id" "pg_catalog"."int4_ops" ASC NULLS LAST
);
CREATE INDEX "IX_medicine_bill_method" ON "public"."medicine_bill" USING btree (
  "method" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table medicine_bill
-- ----------------------------
ALTER TABLE "public"."medicine_bill" ADD CONSTRAINT "PK_medicine_bill" PRIMARY KEY ("id");

-- ----------------------------
-- Auto increment value for medicine_categories
-- ----------------------------
SELECT setval('"public"."medicine_categories_id_seq1"', 12, true);

-- ----------------------------
-- Indexes structure for table medicine_categories
-- ----------------------------
CREATE UNIQUE INDEX "IX_medicine_categories_name" ON "public"."medicine_categories" USING btree (
  "name" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table medicine_categories
-- ----------------------------
ALTER TABLE "public"."medicine_categories" ADD CONSTRAINT "PK_medicine_categories" PRIMARY KEY ("id");

-- ----------------------------
-- Auto increment value for medicine_purchase
-- ----------------------------
SELECT setval('"public"."medicine_purchase_id_seq1"', 50, true);

-- ----------------------------
-- Indexes structure for table medicine_purchase
-- ----------------------------
CREATE INDEX "IX_medicine_purchase_supplier" ON "public"."medicine_purchase" USING btree (
  "supplier" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table medicine_purchase
-- ----------------------------
ALTER TABLE "public"."medicine_purchase" ADD CONSTRAINT "PK_medicine_purchase" PRIMARY KEY ("id");

-- ----------------------------
-- Auto increment value for medicines
-- ----------------------------
SELECT setval('"public"."medicines_id_seq1"', 13, true);

-- ----------------------------
-- Indexes structure for table medicines
-- ----------------------------
CREATE INDEX "IX_medicines_category" ON "public"."medicines" USING btree (
  "category" "pg_catalog"."int4_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table medicines
-- ----------------------------
ALTER TABLE "public"."medicines" ADD CONSTRAINT "PK_medicines" PRIMARY KEY ("id");

-- ----------------------------
-- Auto increment value for payment_method
-- ----------------------------
SELECT setval('"public"."payment_method_id_seq1"', 8, true);

-- ----------------------------
-- Indexes structure for table payment_method
-- ----------------------------
CREATE UNIQUE INDEX "IX_payment_method_name" ON "public"."payment_method" USING btree (
  "name" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table payment_method
-- ----------------------------
ALTER TABLE "public"."payment_method" ADD CONSTRAINT "PK_payment_method" PRIMARY KEY ("id");

-- ----------------------------
-- Auto increment value for settings
-- ----------------------------
SELECT setval('"public"."settings_id_seq1"', 2, true);

-- ----------------------------
-- Primary Key structure for table settings
-- ----------------------------
ALTER TABLE "public"."settings" ADD CONSTRAINT "PK_settings" PRIMARY KEY ("id");

-- ----------------------------
-- Auto increment value for suppliers
-- ----------------------------
SELECT setval('"public"."suppliers_id_seq1"', 13, true);

-- ----------------------------
-- Indexes structure for table suppliers
-- ----------------------------
CREATE UNIQUE INDEX "IX_suppliers_email" ON "public"."suppliers" USING btree (
  "email" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table suppliers
-- ----------------------------
ALTER TABLE "public"."suppliers" ADD CONSTRAINT "PK_suppliers" PRIMARY KEY ("id");

-- ----------------------------
-- Foreign Keys structure for table AspNetRoleClaims
-- ----------------------------
ALTER TABLE "public"."AspNetRoleClaims" ADD CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "public"."AspNetRoles" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table AspNetUserClaims
-- ----------------------------
ALTER TABLE "public"."AspNetUserClaims" ADD CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "public"."AspNetUsers" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table AspNetUserLogins
-- ----------------------------
ALTER TABLE "public"."AspNetUserLogins" ADD CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "public"."AspNetUsers" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table AspNetUserRoles
-- ----------------------------
ALTER TABLE "public"."AspNetUserRoles" ADD CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "public"."AspNetRoles" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "public"."AspNetUserRoles" ADD CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "public"."AspNetUsers" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table AspNetUserTokens
-- ----------------------------
ALTER TABLE "public"."AspNetUserTokens" ADD CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "public"."AspNetUsers" ("Id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table bill_items
-- ----------------------------
ALTER TABLE "public"."bill_items" ADD CONSTRAINT "FK_bill_items_medicine_batch_batch" FOREIGN KEY ("batch") REFERENCES "public"."medicine_batch" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "public"."bill_items" ADD CONSTRAINT "FK_bill_items_medicine_bill_bill_id" FOREIGN KEY ("bill_id") REFERENCES "public"."medicine_bill" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "public"."bill_items" ADD CONSTRAINT "FK_bill_items_medicines_medicine_id" FOREIGN KEY ("medicine_id") REFERENCES "public"."medicines" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table medicine_batch
-- ----------------------------
ALTER TABLE "public"."medicine_batch" ADD CONSTRAINT "FK_medicine_batch_medicine_purchase_purchase_id" FOREIGN KEY ("purchase_id") REFERENCES "public"."medicine_purchase" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "public"."medicine_batch" ADD CONSTRAINT "FK_medicine_batch_medicines_medicine_id" FOREIGN KEY ("medicine_id") REFERENCES "public"."medicines" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table medicine_bill
-- ----------------------------
ALTER TABLE "public"."medicine_bill" ADD CONSTRAINT "FK_medicine_bill_customers_customer_id" FOREIGN KEY ("customer_id") REFERENCES "public"."customers" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "public"."medicine_bill" ADD CONSTRAINT "FK_medicine_bill_payment_method_method" FOREIGN KEY ("method") REFERENCES "public"."payment_method" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table medicine_purchase
-- ----------------------------
ALTER TABLE "public"."medicine_purchase" ADD CONSTRAINT "FK_medicine_purchase_suppliers_supplier" FOREIGN KEY ("supplier") REFERENCES "public"."suppliers" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table medicines
-- ----------------------------
ALTER TABLE "public"."medicines" ADD CONSTRAINT "FK_medicines_medicine_categories_category" FOREIGN KEY ("category") REFERENCES "public"."medicine_categories" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;

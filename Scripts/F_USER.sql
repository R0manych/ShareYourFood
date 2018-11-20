--
-- Создать таблицу "DB_FOOD"."F_USER"
--
CREATE TABLE F_USER (
  ID    NUMBER(10, 0),
  NAME  NVARCHAR2(50),
  EMAIL NVARCHAR2(50),
  CONSTRAINT PK_USER_ID PRIMARY KEY (ID) USING INDEX TABLESPACE SYSTEM STORAGE (INITIAL 64 K
                                                                                NEXT 1 M
                                                                                MAXEXTENTS UNLIMITED)
)
TABLESPACE SYSTEM
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMIT;

--
-- Создать таблицу "DB_FOOD"."FOOD"
--
CREATE TABLE FOOD (
  ID   NUMBER(10, 0),
  NAME VARCHAR2(50 BYTE),
  CONSTRAINT PK_FOOD_ID PRIMARY KEY (ID) USING INDEX TABLESPACE SYSTEM STORAGE (INITIAL 64 K
                                                                                NEXT 1 M
                                                                                MAXEXTENTS UNLIMITED)
)
TABLESPACE SYSTEM
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

COMMIT;
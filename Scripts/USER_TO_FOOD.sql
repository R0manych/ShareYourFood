--
-- Создать таблицу "DB_FOOD"."USER_TO_FOOD"
--
CREATE TABLE USER_TO_FOOD (
  USER_ID NUMBER(10, 0),
  FOOD_ID NUMBER(10, 0),
  DT      DATE,
  CONSTRAINT PK_USER_TO_FOOD PRIMARY KEY (USER_ID, FOOD_ID, DT) USING INDEX TABLESPACE SYSTEM STORAGE (INITIAL 64 K
                                                                                                       NEXT 1 M
                                                                                                       MAXEXTENTS UNLIMITED)
)
TABLESPACE SYSTEM
STORAGE (INITIAL 64 K
         NEXT 1 M
         MAXEXTENTS UNLIMITED)
LOGGING;

--
-- Создать внешний ключ "FK_USER_TO_FOOD_FOOD_ID" для объекта типа таблица "DB_FOOD"."USER_TO_FOOD"
--
ALTER TABLE USER_TO_FOOD
ADD CONSTRAINT FK_USER_TO_FOOD_FOOD_ID FOREIGN KEY (FOOD_ID)
REFERENCES FOOD (ID);

--
-- Создать внешний ключ "FK_USER_TO_FOOD_USER_ID" для объекта типа таблица "DB_FOOD"."USER_TO_FOOD"
--
ALTER TABLE USER_TO_FOOD
ADD CONSTRAINT FK_USER_TO_FOOD_USER_ID FOREIGN KEY (USER_ID)
REFERENCES F_USER (ID);

COMMIT;
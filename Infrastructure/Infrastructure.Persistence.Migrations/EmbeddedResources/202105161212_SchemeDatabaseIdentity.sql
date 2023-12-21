INSERT INTO role(name) VALUES('ADMIN');
INSERT INTO role(name) VALUES('USER');

INSERT INTO app_user("name", last_name, username, email, email_confirmed, "enabled", password_hash, security_stamp)VALUES('Harrinson', 'Gutierrez Coronado', 'HGUTIECO@GMAIL.COM', 'HGUTIECO@GMAIL.COM', true, true, 'AQAAAAEAACcQAAAAEBaPQ2UrmHl8fCXzpxCcAVanvSidtCFJhWfcFNMQYWCYDogjyLSbfx6NDlBLO+KLHg==', 'AXRQIVH42UXP4RMZWZFT2HD2WCHV4J5I');

INSERT INTO user_role(user_id, role_id) VALUES (1, 1);
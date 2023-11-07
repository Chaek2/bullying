from flask import Flask, jsonify
import mysql.connector
cnxn = mysql.connector.connect(host='mysql', port='3306',user="root",password= "password",database= "time_db")
print('DB CONNECTED')

app = Flask(__name__)
cursor = cnxn.cursor() 

sql_table = 'CREATE TABLE IF NOT EXISTS VV ( id INT AUTO_INCREMENT PRIMARY KEY, TROUA TEXT)'
cursor.execute(sql_table)
cnxn.commit()

@app.route('/')
def get_index():
    cursor.execute('SELECT * FROM VV')
    st = cursor.fetchall()
    print(st)
    return jsonify(st)

if __name__ == '__main__':
    app.run(debug=True, port=5050, host='0.0.0.0')
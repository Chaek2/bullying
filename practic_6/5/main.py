from flask import Flask,jsonify
import os
app = Flask(__name__)

@app.route('/')
def index():
    dir_list1 = os.listdir('./app/images')
    dir_list2 = os.listdir('./data')
    dir_list = dir_list1 + dir_list2
    return dir_list

if __name__ == '__main__':
    app.run(debug=True,port=80,host='0.0.0.0')
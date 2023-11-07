from flask import Flask, jsonify
import httpx

app = Flask(__name__)
urls = "http://127.0.0.1:5555/"

@app.route('/')
def get_index():
    r = httpx.get(urls)
    return r

if __name__ == '__main__':
    app.run(debug=True, port=9090, host='0.0.0.0')
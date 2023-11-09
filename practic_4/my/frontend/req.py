from flask import Flask, jsonify
import httpx

app = Flask(__name__)
urls = "http://api:5050/"

@app.route('/')
def get_index():
    r = httpx.get(urls)
    return r.json()

if __name__ == '__main__':
    app.run(debug=True, port=9090, host='0.0.0.0')
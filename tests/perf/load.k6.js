import http from 'k6/http';
import { sleep, check } from 'k6';

export const options = {
  stages: [
    { duration: '1m', target: 20 },
    { duration: '3m', target: 50 },
    { duration: '1m', target: 0 },
  ],
  thresholds: {
    http_req_failed: ['rate<0.01'],           // <1% errors
    http_req_duration: ['p(95)<500']          // p95 < 500ms
  },
};

export default function () {
  const base = __ENV.API_URL || 'http://localhost:5000';
  const res = http.get(`${base}/healthz`);
  check(res, { 'status is 200': (r) => r.status === 200 });
  sleep(1);
}

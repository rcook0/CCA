import http from 'k6/http';
import { sleep, check } from 'k6';

export const options = {
  stages: [
    { duration: '30s', target: 10 },
    { duration: '1m', target: 30 },
    { duration: '30s', target: 0 },
  ],
  thresholds: {
    http_req_failed: ['rate<0.01'],
    http_req_duration: ['p(95)<500']
  },
};

export default function () {
  const base = __ENV.API_URL || 'http://localhost:5000';
  const res = http.get(`${base}/healthz`);
  check(res, { 'status is 200': (r) => r.status === 200 });
  sleep(1);
}

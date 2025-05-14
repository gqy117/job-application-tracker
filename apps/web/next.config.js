/** @type {import('next').NextConfig} */
const nextConfig = {
  async rewrites() {
    return [
      {
        // any request to /api/... in your React code
        source: '/applications/:path*',
        // gets forwarded to your backend
        destination: 'http://localhost:5143/applications/:path*',
      },
    ];
  },
};

export default nextConfig;

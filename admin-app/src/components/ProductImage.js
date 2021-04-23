import React from "react";
import { productRes } from "../httpClient";

export default function ProductImage({ src, text }) {
  return (
    <div>
      {!src ? (
        <span className="text-secondary">No image</span>
      ) : (
        <img width={100} src={productRes + src} alt={`{text}`} />
      )}
    </div>
  );
}
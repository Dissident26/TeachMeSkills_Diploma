import React from "react";

interface DateSectionProps {
  date: Date;
}

export const DateSection = ({ date }: DateSectionProps) => (
  <span>{new Date(date).toLocaleString()}</span>
);

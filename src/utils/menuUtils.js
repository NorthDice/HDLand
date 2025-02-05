import { useCallback, useEffect } from "react";

export const useMenuHandlers = (menuOpen, setMenuOpen, menuRef) => {

  const toggleMenu = () => setMenuOpen((prev) => !prev);

  const handleClickOutside = useCallback((event) => {
    if (menuRef.current && !menuRef.current.contains(event.target)) {
      setMenuOpen(false);
    }
  }, [menuRef, setMenuOpen]);

  useEffect(() => {
    if (menuOpen) {
      document.addEventListener("click", handleClickOutside);
    } else {
      document.removeEventListener("click", handleClickOutside);
    }

    return () => document.removeEventListener("click", handleClickOutside);
  }, [menuOpen, handleClickOutside]);

  return { toggleMenu };
};

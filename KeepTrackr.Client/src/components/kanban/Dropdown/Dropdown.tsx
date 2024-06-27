import React, { useRef,useEffect } from 'react';
import './Dropdown.css'
const Dropdown = (props: any) => {
    const dropRef = useRef<HTMLDivElement>(null)
    const handleClick = (event: any) => {
        if (dropRef && dropRef.current != null && !dropRef.current.contains(event.target) && props.onClose){
          props.onClose()
        }
      };
      useEffect(() => {
        document.addEventListener("click", handleClick,{ capture: true });
    
        return () => {
          document.removeEventListener("click", handleClick,{ capture: true });
        };
      });
    return (
        <div
        ref={dropRef}
        className={`dropdown ${props.class ? props.class : ""}`}
      >
        {props.children}
      </div>
    );
}

export default Dropdown;

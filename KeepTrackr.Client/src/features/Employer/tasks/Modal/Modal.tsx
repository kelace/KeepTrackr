import React from "react";
import "./Modal.css";


const Modal = (props: any) => {
  return (
    <div className="custom__modal" onClick={() => props.onClose(false)}>
      <div
        className="modal__content"
              onClick={(event: any) => event.stopPropagation()}
      >
        {props.children}
      </div>
    </div>
  );
};

export default Modal;
